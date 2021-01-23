    public string Save(Group g)
    {
        string[] arr = g.elementsList.Select(x => x.ToString()).ToArray();
        System.IO.File.WriteAllLines(Path,arr);
    }
