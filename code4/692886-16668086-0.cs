    public TestEnum GetEnumByAttributeName(string attributeName)
    {
        foreach (var item in Enum.GetNames(typeof(TestEnum)))
        {
            var memInfo = typeof(TestEnum).GetMember(item);
            var attributes = memInfo[0].GetCustomAttributes(typeof(CodeAttribute), false);
            if (attributes.Count()> 0 && ((CodeAttribute)attributes[0]).Code == attributeName)
                return (TestEnum)Enum.Parse(typeof(TestEnum), item);
        }
        return TestEnum.None;
    }
