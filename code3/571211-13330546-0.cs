    foreach (XElement xEle in rows)
    {
        IEnumerable<XAttribute> attlist = from att in xEle.DescendantsAndSelf()
                                            .Attributes() select att;
    
        foreach (XAttribute xatt in attlist)
        {
           Console.WriteLine(xatt);
        }
        foreach (XElement elemnt in xEle.Descendants())
        {
           Console.WriteLine(elemnt.Value);
        }
        Console.WriteLine("-------------------------------------------");
    }
