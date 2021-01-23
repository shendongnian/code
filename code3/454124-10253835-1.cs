    public class MapperItem
    {
        public MapperItem(MemberInfo member, object o)
        {
            this.Member = member;
            this.Object = o;
        }
        public MemberInfo Member 
        { 
            get; 
            set; 
        }
        public object Object
        {
            get;
            set;
        }
        public Type Type
        {
            get
            {
                return this.Member.UnderlyingType();
            }
        }
        public object Value
        {
            get
            {
                if (this.Member is PropertyInfo)
                {
                    return (this.Member as PropertyInfo).GetValue(this.Object, null);
                }
                else if (this.Member is FieldInfo)
                {
                    return (this.Member as FieldInfo).GetValue(this.Object);
                }
                else
                {
                    throw new Exception("sourceMember must be either PropertyInfo or FieldInfo");
                }
            }
        }
        public object Convert(Type targetType)
        {
            object converted = null;
            if (this.Value == null)
            {
                return converted;
            }
            else if (targetType.IsAssignableFrom(this.Type))
            {
                converted = this.Value;
            }
            else
            {
                var conversionKey = Tuple.Create(this.Type, targetType);
                if (Conversions.ContainsKey(conversionKey))
                {
                    converted = Conversions[conversionKey](this.Value);
                }
                else
                {
                    throw new Exception(targetType.Name + " is not assignable from " + this.Type.Name);
                }
            }
            return converted;
        }
        public void Assign(object value)
        {
            if (this.Member is PropertyInfo)
            {
                (this.Member as PropertyInfo).SetValue(this.Object, value, null);
            }
            else if (this.Member is FieldInfo)
            {
                (this.Member as FieldInfo).SetValue(this.Object, value);
            }
            else
            {
                throw new Exception("destinationMember must be either PropertyInfo or FieldInfo");
            }
        }
        public static Dictionary<Tuple<Type, Type>, Func<object, object>> Conversions = new Dictionary<Tuple<Type, Type>, Func<object, object>>();
    }
    public class Mapper<S, T>
    {
        private List<string> ignoreList = new List<string>();
        public List<string> IgnoreList
        {
            get { return ignoreList; }
            set { ignoreList = value; }
        }
        public void MapProperties(S source, T target, bool failIfNotMatched = true)
        {
            foreach (PropertyInfo property in source.GetType()
                                                          .GetProperties()
                                                          .Where(c => !IgnoreList.Contains(c.Name)))
            {
                try
                {
                    var sourceField = new MapperItem(property, source);
                    var targetField = new MapperItem(MatchToTarget(property), target);
                    targetField.Assign(sourceField.Convert(targetField.Type));
                }
                catch (TargetNotMatchedException noMatch)
                {
                    if (failIfNotMatched)
                    {
                        throw noMatch;
                    }
                }
            }
        }
        private MemberInfo MatchToTarget(MemberInfo member)
        {
            List<MemberInfo> members = new List<MemberInfo>();
            members.AddRange(typeof(T).GetProperties());
            members.AddRange(typeof(T).GetFields());
            var exactMatch = from c in members where c.Name == member.Name select c;
            if (exactMatch.FirstOrDefault() != null)
            {
                return exactMatch.First();
            }
            var sameAlphaChars = from c in members
                                 where NormalizeName(c.Name) == NormalizeName(member.Name)
                                 select c;
            if (sameAlphaChars.FirstOrDefault() != null)
            {
                return sameAlphaChars.First();
            }
            throw new TargetNotMatchedException(member, typeof(T));
        }
        private static string NormalizeName(string input)
        {
            string normalized = input.Replace("_", "").ToUpper();
            return normalized;
        }
    }
    public class TargetNotMatchedException : Exception
    {
        public TargetNotMatchedException(MemberInfo member, Type type)
            : base("no match for member named " + member.Name + " with type named " + type.Name)
        {
            this.Member = member;
            this.Type = type;
        }
        public MemberInfo Member { get; set; }
        public Type Type { get; set; }
    }
