    public bool ResponceSearch(string search) {
         var node = 
             (from p in Nodes
              where Regex.Matches(p.Key, search)
              select p.Value)
             .FirstOrDefault();
         if (node != null) {
             label1.Text = node.GetResult();
             return true;
         }
    }
