        public static string GetDescription(this Enum enumeration)
        {
            var desc = enumeration.GetType().GetMember(enumeration.ToString())[0]
                .GetCustomAttributes(typeof(DescriptionAttribute), true) as DescriptionAttribute[];
            if (desc != null && desc.Length > 0)
            {
                return desc[0].Description;
            }
            return enumeration.ToString();
        }
