    PersonGender pg = PersonGender.InadequatelyDescribed;
    string pgName = Enum.GetName(typeof(PersonGender), pg);
    var t = typeof(PersonGender);
    var info = t.GetMember(pgName);
    var att = info[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);
    if (att.Length > 0)
    {
        Console.WriteLine(((EnumMemberAttribute)att[0]).Value);
    }
    else
    {
        Console.WriteLine(pgName);
    }
