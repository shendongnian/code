     var list = new List<MyObject>(){ new MyObject{ Key = 1 , ParentKey = null } , new MyObject{Key=2 , PatentKey = 1}  /* and so on */};
    
      var sortedList = list.OrderBy(o=>o.ParentKey , new MyComparer());
    
    
    
    public class MyComparer : IComparer<MyObject>
    {     
        public int Compare(MyObject o1, MyObject o2)
        {
            if (ol.HasValue && o2.HasValue)
            {
                if (ol.ParentKey.Value == o2.ParentKey.Value)
                     return 0;
                return ol.ParentKey.Value  > o2.ParentKey.Value  ? 1 : -1;
            }
            else
                return 0;
    
        }
    }
