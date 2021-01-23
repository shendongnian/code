    public class PrintJobs
    {
      // ctor logic here
    
    
      private readonly List<Tuple<int, string>> _printJobs = new List<Tuple<int, string>>();
    
      public void AddJob(string value, int count = 1) // default to 1 copy
      {
        this._printJobs.Add(new Tuple<int, string>(count, value));
      }
    
      public void PrintAllJobs()
      {
        foreach(var j in this._printJobs)
        {
          // print job
        }
      }
    }
}
