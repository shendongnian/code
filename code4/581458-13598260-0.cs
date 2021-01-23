     public IEnumerable<Earthquake> GetData(string filename)
         {
             string[] text = File.ReadAllLines(filename);
             foreach (string line in text)
             {
                 string[] myColumns = line.Split(',');
                 yield return new Earthquake(myColumns[0].Trim(), myColumns[1].Trim(), myColumns[2].Trim(), myColumns[3].Trim(), myColumns[4].Trim(), myColumns[5].Trim(), myColumns[6].Trim(), myColumns[7].Trim());
             }
         }
