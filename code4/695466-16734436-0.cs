    namespace Test
    {
        public class Core
        {
            List<MyItem> MyItemList = new List<MyItem>();
    
            public void AddSubitem()
            {
                SubItem sItem = new SubItem();
                sItem.ItemType = "TYPE2"; // it's updating
    
                MyItem mItem = new MyItem();
                this.MyItemList.Add(mItem);
    
                this.MyItemList[0].sItem.Add(sItem);
            }
        }
    
        public class MyItem
        {
            public List<SubItem> sItem = new List<SubItem>();
        }
    
        public class SubItem
        {
            public string ItemType { get; set; }
    
            public SubItem()
            {
                this.ItemType = "TYPE1"; // it's updating
            }
        }
    }
     
