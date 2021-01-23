        public static dynamic ToValues(this Type enumType)
        {
            var values = Enum.GetValues(enumType);
            Type list = typeof(List<>);
            Type resultType = list.MakeGenericType(enumType);
            dynamic result =  Activator.CreateInstance(resultType);
            foreach (var value in values)
            {
                dynamic concreteValue = Enum.Parse(enumType, value.ToString());
                result.Add(concreteValue);
            }
            return resultType;
        }
