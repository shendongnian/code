        public static object ToEnum(string codeToFind, Type t)
        {
            foreach (var enumValue in Enum.GetValues(t))
            {
                CodeAttribute[] codes = (CodeAttribute[])(enumValue.GetType().GetField(enumValue.ToString()).
                GetCustomAttributes(typeof(CodeAttribute), false));
                if (codes.Length > 0 && codes[0].Code.Equals(codeToFind, StringComparison.InvariantCultureIgnoreCase) ||
                    enumValue.ToString().Equals(codeToFind, StringComparison.InvariantCultureIgnoreCase))
                    return enumValue;
            }
            return null;
        }
