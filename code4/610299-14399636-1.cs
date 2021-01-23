    public IEnumerable<Metric> ReadFile()
    {
        string s;
        while ((s=myFileReader.ReadLine())!=null)
        {
            yield return Parse(s);
        }
    }
    int someAnalysis = ReadFile().Sum((a)=>(a.Metric1.Length)); // or whatever you do
