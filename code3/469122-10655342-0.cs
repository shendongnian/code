    public static void Replace(filepath)
    {
        try
        {
            XElement xD = XElement.Load(filePath);
            foreach (XElement xE in xD.Elements())
            {
                if (xE.Attribute("attr") != null)
                {
                    Console.WriteLine(xE.Attribute("attr").Value);
                    if (Regex.IsMatch(xE.Attribute("attr").EndsWith("AA"))
                    {
                        Console.WriteLine("match");
                        tuv.Attribute("attr").Value.Replace("AA", "");
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
