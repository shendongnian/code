    public class MyClass
    {
      private BlockingCollection<workUnit> workUnits = new BlockingCollection<workUnit>();
      public void EnQueue(workUnit item)
      {
        workUnits.Add(item);
      }
    
      private void DeQueue()
      {
        while (!stopFlag)
        {
          workUnit item = workUnits.Take();
          item.SetState("Processing Started");
          try
          {
              DoLongRunningDBStuff(workUnit);
              item.SetState("Processing Successful");
          }
          catch
          {
              item.SetState("Processing Failed");
          }
        }
      }
    } 
