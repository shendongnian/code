    public class CustomDictionaryType : IUserType
    {
        public CustomDictionaryType()
        {
            SqlTypes = Enumerable.Range(0, 14).Select(x => SqlTypeFactory.Int32).ToArray();
        }
        public bool Equals(object x, object y)
        {
            // should do a key/value comparison here
            return ReferenceEquals(x, y);
        }
        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            // DayOfWeek.Sunday = 0, so have to shift days down by one since we start with Monday in our columns
            return names.Select((x, i) => new {DayOfWeek = GetDay(i/2), value = (int) rs[x]})
                .GroupBy(x => x.DayOfWeek, x => x.value)
                .ToDictionary(g => g.Key, g => new PlantOpeningHours
                                                   {
                                                       DayOfWeek = g.Key,
                                                       StartMinutes = g.First(),
                                                       DurationMinutes = g.First() - g.Last()
                                                   });
        }
        private DayOfWeek GetDay(int index)
        {
            return (DayOfWeek) ((index + 6)%7);
        }
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            var map = value as IDictionary<DayOfWeek, PlantOpeningHours>;
            if (map == null)
                throw new ArgumentException("Cannot handle null dictionary");
            for(var i = 0; i < 7; i++)
            {
                var day = GetDay(i);
                var entry = map[day];
                ((IDataParameter) cmd.Parameters[index + i*2]).Value = entry.StartMinutes;
                ((IDataParameter) cmd.Parameters[index + i*2 + 1]).Value = entry.StartMinutes + entry.DurationMinutes;
            }
        }
        public object DeepCopy(object value)
        {
            return new Dictionary<DayOfWeek, PlantOpeningHours>((IDictionary<DayOfWeek, PlantOpeningHours>) value);
        }
        public object Replace(object original, object target, object owner)
        {
            return new Dictionary<DayOfWeek, PlantOpeningHours>((IDictionary<DayOfWeek, PlantOpeningHours>)original);
        }
        public object Assemble(object cached, object owner)
        {
            return DeepCopy(cached);
        }
        public object Disassemble(object value)
        {
            return DeepCopy(value);
        }
        public SqlType[] SqlTypes { get; private set; }
        public Type ReturnedType { get { return typeof (IDictionary<DayOfWeek, PlantOpeningHours>); } }
        public bool IsMutable { get { return true; } }
    }
