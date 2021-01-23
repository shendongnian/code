    public void Frequenty(string[] path1)
          {
             List<string> filesCollection = new List<string>();
             for (int i = 0; i < DistincTerms.Count(); i++ )
             {
                 string d = DistincTerms.ElementAt(i);
                 foreach (string f in path1)
                 {
                     string c = File.ReadAllText(f);
                     c = r.RemoveNonAlphaChars(c);
                     String[] T = r.RemoveStopsWords(c.ToUpper().Split(' '));
                     foreach (string term in T)
                     {
                         if (term.Equals(d) && !filesCollection.Contains(f))
                         {
                             filesCollection.Add(f);
                         }
                     }
                 }
                 countor.Add(filesCollection.Count);
                 index.Add(d, countor);
                 filesCollection.Clear();
             }
      
