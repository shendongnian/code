    public static void Replace(filepath)
    {
        try
        {
            XElement xD = XElement.Load(filePath);
            foreach (XElement xE in xD.Descendants())
            {
                if (xE.Attribute("attr") != null)
                {
                    Console.WriteLine(xE.Attribute("attr").Value);
                    if (Regex.IsMatch(xE.Attribute("attr").Value))
                    {
                        Console.WriteLine("match");
                        xE.Attribute("attr").Value.Replace("AA", "");
                    }
                    Console.WriteLine(xE.Attribute("attr").Value);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Failure in Replace: {0}", e.ToString());
        }
    }
