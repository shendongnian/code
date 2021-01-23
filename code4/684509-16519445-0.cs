    public void Frequenty(string[] path1)
          {
              List<string> filesCollection = new List<string>();
            foreach (string d in DistincTerms)
            {
                foreach (string f in path1)
                {
                    
                    string c = File.ReadAllText(f);
                    String[] T = c.ToUpper().Split(' ');
                    foreach (string term in T)
                    {
                        if (term.Equals(d) && !filesCollection.Contains(f))
                        {
                            filesCollection.Add(f);
                        }
                    }
                }
                index.Add(d, filesCollection);
              }
          }
