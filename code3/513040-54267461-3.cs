    //Way to use
    //ResetToDefaultValue(TestSettings.Default, x => x.TextFieldStuff);
    private static void ResetToDefaultValue<T1, T2>(T1 settings, Expression<Func<T1, T2>> property, bool saveOnReset = true)
    {
        //Requires C# >= 7.1
        if (settings is ApplicationSettingsBase s)
        {
            MemberInfo member = GetMemberInfo(property);
            if (!s.PropertyValues[member.Name].UsingDefaultValue)
            {
                s.PropertyValues[member.Name].PropertyValue = s.PropertyValues[member.Name].Property.DefaultValue;
                s.PropertyValues[member.Name].Deserialized = false;
                s[member.Name] = s.PropertyValues[member.Name].PropertyValue;
                if (saveOnReset)
                {
                    s.Save();
                }
            }
        }
    }
    //Way to use
    //GetMemberInfo((TestSettings testSettings) => testSettings.TextFieldStuff);
    private static MemberInfo GetMemberInfo<T1, T2>(Expression<Func<T1, T2>> expression)
    {
        //Requires C# >= 7.0
        if (expression.Body is MemberExpression member)
        {
            return member.Member;
        }
        throw new ArgumentException(@"Expression is not a member access", nameof(expression));
    }
