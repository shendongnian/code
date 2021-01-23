    public class MyClassThatDoesSomething
    {
       private List<string> list = new List<string>();
       public void ProcessList()
       {
          foreach(var item in list)
          {
             ProcessItem(item);
             //how do we notify someone here??
          }
       }
    
       private void ProcessItem(string item){}
    }
