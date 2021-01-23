         public int getRealCount()
        {
            List<string> all = new List<string>(originList);
        
            all.Remove("");
        
            return all.Count;
         }
