    public class ProcessListener : IItemProcessed
    {
       public void ItemProcessed(string item)
       {
          Console.WriteLine(item);
          //update progress bar, whatever
       }
    }
    var mc = new MyClassThatDoesSomething();
    mc.Listener = new ProcessListener();
    mc.ProcessList(); 
