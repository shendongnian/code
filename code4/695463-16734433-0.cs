     public class Core {
           public SyncList<MyItem> Items{get; set;}
    
    	   public Core(){
    			Items = new SyncList<MyItem>;
    	   }
    	   
           public void AddSubItem(){
    			MyItem item = new MyItem();
    			SubItem i = new SubItem();
    			i.ItemType = "TYPE1"; // not updating
    			item.SubItems.Add(i);
    			Items.Add(item);           
           }
      }
    
      public class MyItem {
           public SyncList<SubItem> SubItems {get; set;}
    	   
    	   public SubItem(){
    			SubItems = new SyncList<SubItem>();
    	   }
      }
    
      public class SubItem {
    
           public string ItemType { get; set; }
      }
