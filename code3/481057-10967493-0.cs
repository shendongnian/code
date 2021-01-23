     var list = new List<MyObject>(){ new MyObject{ Key = 1 , ParentKey = null } , new MyObject{Key=2 , PatentKey = 1}  /* and so on */};
    
      var sortedList = list.OrderBy(o=o.ParentKey , new MyComparer());
    
    
    
    public class MyComparer : IComparer<MyObject>
    {     
        public int Compare(MyObject o1, MyObject o2)
        {
            if (ol.hasvalues)
                return ol.ParentKey > o2.ParentKey ? 1 : -1;
            else
                return 0;
    
        }
    }
