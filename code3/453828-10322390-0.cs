    public class ToDoList
    {
      public IList<ToDoListItem> Items { get; private set; }
      
      // factory method creates items as required by ToDoList
      public ToDoListItem Create(string title)
      {
        var item = new ToDoListItem(this, title);
        this.Items.Add(item);
        return item;
      }
    
      ToDoListItem currentItem;
    
      public void StartTrackTimeFor(ToDoListItem item) 
      {
        if (this.currentItem != null)
          throw new Exception();
        // could also throw different exception if specified item is current item being tracked
        // start time tracking logic.
        this.currentItem = item;
      }
    
      public void StopTrackTimeFor(ToDoListItem item)
      {
        if (this.currentItem != item)
          throw new Exception();
        // stop time tracking logic.    
        this.currentItem = null;
      }
    }
    
    public class ToDoListItem
    {
      public ToDoListItem(ToDoList list, string title) 
      {
        this.ToDoList = list;
        this.Title = title;
      }
      
      public ToDoList ToDoList { get; private set; }
      
      public string Title { get; private set; }
      
      public void StartTrackTime()
      {
        this.ToDoList.StartTrackTimeFor(this);
      } 
      
      public void StopTrackTime()
      {
        this.ToDoList.StopTrackTimeFor(this);
      }
    }
