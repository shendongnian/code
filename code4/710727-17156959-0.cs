        //This structure represents the comparison of one member of an object to the corresponding member of another object.
        public struct MemberComparison
        {
            public static PropertyInfo NullProperty = null; //used for ROOT properties - i dont know their name only that they are changed
            
            public readonly MemberInfo Member; //Which member this Comparison compares
            public readonly object Value1, Value2;//The values of each object's respective member
            public MemberComparison(PropertyInfo member, object value1, object value2)
            {
                Member = member;
                Value1 = value1;
                Value2 = value2;
            }
            public override string ToString()
            { 
                return Member.name+ ": " + Value1.ToString() + (Value1.Equals(Value2) ? " == " : " != ") + Value2.ToString();
            }
        }
        //This method can be used to get a list of MemberComparison values that represent the fields and/or properties that differ between the two objects.
        public static List<MemberComparison> ReflectiveCompare<T>(T x, T y)
        {
            List<MemberComparison> list = new List<MemberComparison>();//The list to be returned
            if (x.GetType().IsArray)
            {
                Array xArray = x as Array;
                Array yArray = y as Array;
                if (xArray.Length != yArray.Length)
                    list.Add(new MemberComparison(MemberComparison.NullProperty, "array", "array"));
                else
                {
                    for (int i = 0; i < xArray.Length; i++)
                    {
                        var compare = ReflectiveCompare(xArray.GetValue(i), yArray.GetValue(i));
                        if (compare.Count > 0)
                            list.AddRange(compare);
                    }
                }
            }
            else
            {
                foreach (PropertyInfo m in x.GetType().GetProperties())
                    //Only look at fields and properties.
                    //This could be changed to include methods, but you'd have to get values to pass to the methods you want to compare
                    if (!m.PropertyType.IsArray && (m.PropertyType == typeof(String) || m.PropertyType == typeof(double) || m.PropertyType == typeof(int) || m.PropertyType == typeof(uint) || m.PropertyType == typeof(float)))
                    {
                        var xValue = m.GetValue(x, null);
                        var yValue = m.GetValue(y, null);
                        if (!object.Equals(yValue, xValue))//Add a new comparison to the list if the value of the member defined on 'x' isn't equal to the value of the member defined on 'y'.
                            list.Add(new MemberComparison(m, yValue, xValue));
                    }
                    else if (m.PropertyType.IsArray)
                    {
                        Array xArray = m.GetValue(x, null) as Array;
                        Array yArray = m.GetValue(y, null) as Array;
                        if (xArray.Length != yArray.Length)
                            list.Add(new MemberComparison(m, "array", "array"));
                        else
                        {
                            for (int i = 0; i < xArray.Length; i++)
                            {
                                var compare = ReflectiveCompare(xArray.GetValue(i), yArray.GetValue(i));
                                if (compare.Count > 0)
                                    list.AddRange(compare);
                            }
                        }
                    }
                    else if (m.PropertyType.IsClass)
                    {
                        var xValue = m.GetValue(x, null);
                        var yValue = m.GetValue(y, null);
                        if ((xValue == null || yValue == null) && !(yValue == null && xValue == null))
                            list.Add(new MemberComparison(m, xValue, yValue));
                        else if (!(xValue == null || yValue == null))
                        {
                            var compare = ReflectiveCompare(m.GetValue(x, null), m.GetValue(y, null));
                            if (compare.Count > 0)
                                list.AddRange(compare);
                        }
                    }
            }
            return list;
        }
