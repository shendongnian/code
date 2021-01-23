    List<Test> list = new List<Test>
    {
         new Test
         {
             Name = "Test 1",
             Desc = "Desc 1"
         }
    };
    var temp = list.Select(t =>
                    {
                        Dictionary<string, object> values = new Dictionary<string, object>();
                        foreach (PropertyInfo pi in t.GetType().GetProperties())
                            values[pi.Name] = pi.GetValue(t, null);
                        return values;
                    })
                   .FirstOrDefault();
    temp.ToList().ForEach(p => Console.WriteLine(string.Format("{0}:\t{1}", p.Key, p.Value)));
    
