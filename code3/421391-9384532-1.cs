    public class MyClassThatDoesSomething
    {
       private List<string> list = new List<string>();
       public void ProcessList()
       {
          foreach(var item in list)
          {
             ProcessItem(item);
             //how do we notify someone here??
             if(this.Listener != null)
             {
                 this.Listener.ItemProcessed(item);
             }
          }
       }
    
       private void ProcessItem(string item){}
    
       public IItemProcessed Listener {get;set;}
    }
