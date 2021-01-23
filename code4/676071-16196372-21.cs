    private readonly List<int> ids = new List<int>();
    private readonly IList<double> values = new List<double>();
    public void LoadData(string path)
    {
        foreach (var line in File.ReadLines(path))
        {
            var pair = line.Split(' ');
            this.ids.Add(int.Parse(pair[0]));
            this.values.Add(double.Parse(pair[1]));
        }
    }
    public double Lookup(int id)
    {
        return this.values[this.ids.FindIndex(i => i >= id)];
    }
