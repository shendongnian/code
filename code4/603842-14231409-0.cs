        string className = "This_is_MY_CLASS Name/with<silly|chars";
        var invalid = System.IO.Path.GetInvalidFileNameChars().Concat(new char[]{' '});
    
        string newName = new string( new CultureInfo(CultureInfo.CurrentCulture.LCID, false)
            .TextInfo.ToTitleCase(className.ToLower())
            .Select(s => invalid.Contains(s) ? '_' : s).ToArray());
    
       // returns: "This_Is_My_Class_Name_With_Silly_Chars"
