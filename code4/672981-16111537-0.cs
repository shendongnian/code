    private List<double> GetValuesFromFile(string fileName)
    {
          //TBD
    }
    
    private void RetrieveAllFileValues()
    {
         IEnumerable<string> files = ...;
         ConcurrentDictionary<int, List<double>> dict = new ConcurrentDictionary<int, List<double>>();
         Parallel.ForEach(files, file =>
               {
                   var values = GetValuesFromFile(file);
                   dict.Add(file, values);
               });
    }
