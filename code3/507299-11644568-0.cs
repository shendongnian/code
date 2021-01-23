    ///<summary>
    /// Allows the discovery of an enumeration text value based on the <c>EnumTextValueAttribute</c>
    ///</summary>
    /// <param name="e">The enum to get the reader friendly text value for.</param>
    /// <returns><see cref="System.String"/> </returns>
    public static string GetEnumTextValue(Enum e)
    {
        string ret = "";
        Type t = e.GetType();
        MemberInfo[] members = t.GetMember(e.ToString());
        if (members.Length == 1)
        {
            object[] attrs = members[0].GetCustomAttributes(typeof (EnumTextValueAttribute), false);
            if (attrs.Length == 1)
            {
                ret = ((EnumTextValueAttribute)attrs[0]).Text;
            }
        }
        return ret;
    }
