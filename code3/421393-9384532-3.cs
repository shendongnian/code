    public class MyClassThatDoesSomething
    {
       private List<string> list = new List<string>();
       public void ProcessList()
       {
          foreach(var item in list)
          {
             ProcessItem(item);
             //how do we notify someone here??
             if(this.Callback != null)
             {
                 this.Callback(item);
             }
          }
       }
    
       private void ProcessItem(string item){}
    
       public Action<string> Callback {get;set;}
    }
