    //Way to use
    //ResetToDefaultValue(TestSettings.Default, x => x.TextFieldStuff);
    private static void ResetToDefaultValue<T1, T2>(T1 settings, Expression<Func<T1, T2>> property, bool saveOnReset = true)
    {
        if (IsSameOrSubclass(typeof(ApplicationSettingsBase), settings.GetType()))
        {
            ApplicationSettingsBase s = settings as ApplicationSettingsBase;
            if (s != null)
            {
                MemberInfo member = GetMemberInfo(property);
                s[member.Name] = s.PropertyValues[member.Name].Property.DefaultValue;
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
        if (IsSameOrSubclass(typeof(MemberExpression), expression.Body.GetType()))
        {
            MemberExpression member = (MemberExpression)expression.Body;
            return member.Member;
        }
        
        throw new ArgumentException(@"Expression is not a member access", nameof(expression));
    }
    private static bool IsSameOrSubclass(Type potentialBase, Type potentialDescendant)
    {
        return potentialDescendant.IsSubclassOf(potentialBase)
               || potentialDescendant == potentialBase;
    }
