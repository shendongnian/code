       public int getRealCount()
       {
            List<string> all = new List<string>(originList);
        
           int erased =all.RemoveAll(delegate(string s)
            {
                return s == "";
            });
            return all.Count - erased;
       }
