     public static List<DragAndDropData> getdata()
     {
             List<DragAndDropData> LeftSideList=new List<DragAndDropData>();
             if(Session["leftside"]!=null)
             {
		       LeftSideList=(List<DragAndDropData>)Session["leftside"];
             }
             else
             {
               LeftSideList.Add(new DragAndDropData { Id = 0, Name = "Item1" });
               LeftSideList.Add(new DragAndDropData { Id = 1, Name = "Item2" });
               LeftSideList.Add(new DragAndDropData { Id = 2, Name = "Item3" });
               LeftSideList.Add(new DragAndDropData { Id = 3, Name = "Item4" });
               LeftSideList.Add(new DragAndDropData { Id = 4, Name = "Item5" });
            
		}
             return LeftSideList;
     } 
