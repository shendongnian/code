     internal static IEnumerable<Tuple<int,Type>> TypeHierarchy(this Type type)
        {
            var ct = type;
            var cl = 0;
            while (ct != null)
            {
                yield return new Tuple<int, Type>(cl,ct);
                ct = ct.BaseType;
                cl++;
            }
        }
        internal class PropertyInfoComparer : EqualityComparer<PropertyInfo>
        {
            public override bool Equals(PropertyInfo x, PropertyInfo y)
            {
                var equals= x.Name.Equals(y.Name);
                return equals;
            }
            public override int GetHashCode(PropertyInfo obj)
            {
                return obj.Name.GetHashCode();
            }
        }
        internal static IEnumerable<PropertyInfo> GetRLPMembers(this Type type)
        {
            
            return type
                .TypeHierarchy()
                .SelectMany(t =>
                    t.Item2
                    .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(prop => Attribute.IsDefined(prop, typeof(RLPAttribute)))
                    .Select(
                        pi=>new Tuple<int,PropertyInfo>(t.Item1,pi)
                    )
                 )
                .OrderByDescending(t => t.Item1)
                .ThenBy(t => t.Item2.GetCustomAttribute<RLPAttribute>().Order)
                .Select(p=>p.Item2)
                .Distinct(new PropertyInfoComparer());
            
         
        }
