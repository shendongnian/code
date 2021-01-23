    List<IEnumerable<XElement>> World = new List<IEnumerable<XElement>>();
    for (int i = 0; i < noofworlds; i++)
    {
        World.Add(LevelData.Root.Elements("world").Where(element => (int?)element.Attribute("id") == i));//with id == to i
    }
