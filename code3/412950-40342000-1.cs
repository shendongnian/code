        public static string Serialize<TEnum>(TEnum value)
        {
            var fallback = Enum.GetName(typeof(TEnum), value);
            var member = typeof(TEnum).GetMember(value.ToString()).FirstOrDefault();
            if (member == null)
                return fallback;
            var enumMemberAttributes = member.GetCustomAttributes(typeof(EnumMemberAttribute), false).Cast<EnumMemberAttribute>().FirstOrDefault();
            if (enumMemberAttributes == null)
                return fallback;
            return enumMemberAttributes.Value;
        }
        public static TEnum Deserialize<TEnum>(string value) where TEnum : struct
        {
            TEnum parsed;
            if (Enum.TryParse<TEnum>(value, out parsed))
                return parsed;
            var found = typeof(TEnum).GetMembers()
                .Select(x => new
                {
                    Member = x,
                    Attribute = x.GetCustomAttributes(typeof(EnumMemberAttribute), false).OfType<EnumMemberAttribute>().FirstOrDefault()
                })
                .FirstOrDefault(x => x.Attribute?.Value == value);
            if (found != null)
                return (TEnum)Enum.Parse(typeof(TEnum), found.Member.Name);
            return default(TEnum);
        }
    }
