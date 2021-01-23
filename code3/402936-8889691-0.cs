     Dictionary<string, string> svrs = new Dictionary<string, string>();
                svrs.Add("NLDN1234", "ok");
                svrs.Add("NLDN1235", "ok");
                svrs.Add("NSTM2345", "ok");
                svrs.Add("NSTM9874", "ok");
                
                SortedDictionary<string, string> sortedSvrs = new SortedDictionary<string, string>(svrs);
    
                for (int i = 0; i < sortedSvrs.Keys.Count; i++)
                {
                    var key = sortedSvrs.Keys.ElementAt(i);
                    Console.WriteLine(key +" " + sortedSvrs[key]);
                    // any extra operation
                    //
                }
