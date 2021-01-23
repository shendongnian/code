    public string Save(Group g)
    {
        string[] lines = g.elementsList.ConvertAll(p => p.ToString()).ToArray();
        System.IO.File.WriteAllLines(Path, lines );
    }
