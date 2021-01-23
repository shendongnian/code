    public class VariablesRepository : IVariablesRepository
    {
         public static Variables Find(string name)
         {
           return DBContextClass.Current.Variables.FirstOrDefault(c =>   c.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)) ?? new Variables();
         }
    }
    public class Defaults
    {
        public class MOSScheduleTypes
        {
            private static int _tryValue;
            public static readonly int OneTime = int.TryParse(VariablesRepository.Find("MOSScheduleTypes.OneTime").Value, out _tryValue)
                                                            ? _tryValue
                                                            : 1;
        }
    }
