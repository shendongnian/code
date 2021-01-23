     public static IEnumerable<string> Combine<T>(string prefix, 
                                                  string separator, 
                                                  List<List<T>> collections, 
                                                  int level, List<string> tmpList)
        {
            if (separator == null)
                separator = "";
            if (prefix == null)
                prefix = "";
           
            List<string> nextTmpList  = new List<string>();
            int length = collections.Count();
            if (tmpList == null || tmpList.Count == 0)
            {
                tmpList = new List<string>();
                foreach (var ob in collections.Last())
                    tmpList.Add(ob.ToString());
            }
            
            if(length == level)
            {
                foreach (string s in tmpList)
                    nextTmpList.Add(prefix + separator + s.ToString());
                return nextTmpList;
            }
            
            foreach (var comb in tmpList)
                foreach(var ob in collections[length - level - 1])
                    nextTmpList.Add(ob.ToString() + separator + comb);
            return Combine(prefix, separator, collections, level + 1, nextTmpList);
                
        }
