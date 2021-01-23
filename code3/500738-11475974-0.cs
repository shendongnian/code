            public static IEnumerable<TSource> CustomOrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            List<string> list=new List<string>();
            List<TSource> returnList=new List<TSource>();
            List<int> indexList = new List<int>();
            if (source == null)
                return null;
            if (source.Count() <= 0)
                return source;
            source.ToList().ForEach(sc=>list.Add(keySelector(sc).ToString())); //Extract the strings of property to be ordered
            
            list.Sort(); //sort the list of strings
            
            foreach (string l in list) // extract the list of indexes of source according to the order
            {
                int i=0;
                //list.ForEach(l =>
                
                    foreach (var s in source.ToList())
                    {
                        if (keySelector(s).ToString() == l)
                            break;
                        i++;
                    }
                    indexList.Add(i);
            }
            indexList.ForEach(i=>returnList.Add(source.ElementAt(i))); //rearrange the source according to the above extracted indexes
            return returnList;
        }
    }
    public class Name
    {
        public string FName { get; set; }
        public string LName { get; set; }
    }
    public class Category
    {
        public Name Name { get; set; }
    }
    public class SortChild
    {
        public void SortOn()
        {
            List<Category> category = new List<Category>{new Category(){Name=new Name(){FName="sahil",LName="chauhan"}},
                new Category(){Name=new Name(){FName="pankaj",LName="chauhan"}},
                new Category(){Name=new Name(){FName="harish",LName="thakur"}},
                new Category(){Name=new Name(){FName="deepak",LName="bakseth"}},
                new Category(){Name=new Name(){FName="manish",LName="dhamaka"}},
                new Category(){Name=new Name(){FName="arev",LName="raghaka"}}
            };
            var a = category.CustomOrderBy(s => s.Name.FName);
        
        }
    
    }
