                int i = lst.Count - 1;
                foreach (YourClass item in lst.Reverse<YourClass>())
                {
                    lst.Insert(i, item);
                    lst.RemoveAt(i);
                    i--;
                }
    
                //if you dont know the type make an array
    
                int i = countries.Count - 1;
                foreach (var item in lst.ToArray())
                {
                   lst.Insert(i, item);
                   lst.RemoveAt(i);
                   i--;
                }
