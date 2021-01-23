    Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
    string line;
    int count = -1;
    using (var reader = File.OpenText(@"C:\Users\Jose\Desktop\bla.txt"))
    {
          while ((line = reader.ReadLine()) != null)
          {
               if (!Regex.IsMatch(line, @"\d"))
               {
                   results.Add(line, new List<string>());
                   count++;
               }
               else
               {
                    results.ElementAt(count).Value.Add(line);
               }
           }
                   
    }
