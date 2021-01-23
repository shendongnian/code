    for (int i = 0; i < doc2.Root.Descendants().Count(); i++)
    {
        String name = doc2.Root.Descendants()[i].Name.LocalName;
        String value = doc2.Root.Descendants()[i].Value;
    }
