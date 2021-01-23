    try
    {
        MemberList g = new MemberList("group name");
        g.members[0] = new Member("mem 1");
        g.members[1] = new Member("mem 2");
        g.members[2] = new Member("mem 3");
        StringWriter sw = new StringWriter();
        XmlTextWriter tw = new XmlTextWriter(sw);
        tw.Formatting = Formatting.Indented;
        tw.Indentation = 4;
        XmlSerializer ser = new XmlSerializer(typeof(MemberList));
        ser.Serialize(tw, g);
        tw.Close();
        sw.Close();
        Console.WriteLine(sw.ToString());
    }
    catch(Exception exc)
    {
        Console.WriteLine(exc.Message);
    }
