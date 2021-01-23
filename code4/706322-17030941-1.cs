    public List<double> NewData
    {
        get;
        set;
    }
    public InfoFile(String fileName, String groupName)
    {
        // initialize NewData to a new instance of List<double>
        NewData = new List<double>(); 
        this.group = groupName;
        test = File.ReadAllLines(fileName);
        FileInfo label = new FileInfo(fileName);
        this.name = Path.GetFileName(fileName);
        isDrawn = false;
        for (int t = 2; t < test.Length; t++)
        {
            NewData.Add(double.Parse(test[t].Substring(6, 4)));
        }
    }
