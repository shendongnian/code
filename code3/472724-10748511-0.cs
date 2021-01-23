     private List<int> list = Enumerable.Range(0, 10).ToList<int>();
     for(int i=0;i<list.Count;++i)
           {
               if (list[i] < 5)
                   list.RemoveAt(i);
           }
           list.ForEach(x => Console.Write(x));
