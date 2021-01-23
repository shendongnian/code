    List<string> sectionsResult = new List<string>();
    List<string> categorysResult = new List<string>();
    string astring="#This is a Section*This is the first category*This is thesecond Category# This is another Section";
    var sections = astring.Split('#').Where(i=> !String.IsNullOrEmpty(i));
    foreach (var section in sections)
    {
        var sectieandcategorys =  section.Split('*');
        sectionsResult.Add(sectieandcategorys.First());
        categorysResult.AddRange(sectieandcategorys.Skip(1));
    }
