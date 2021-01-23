    private static string GetProcessInstanceName(int pid)
    {
      PerformanceCounterCategory cat = new PerformanceCounterCategory("Process");
    
      string[] instances = cat.GetInstanceNames();
      foreach (string instance in instances)
      {
    
         using (PerformanceCounter cnt = new PerformanceCounter("Process",  
              "ID Process", instance, true))
         {
            try
            {
               int val = (int) cnt.RawValue;
               if (val == pid)
               {
                  return instance;
               }
            }
            catch (InvalidOperationException)
            {
               // EDIT: this can happen if the process dies before this code requests RawValue
            }
         }
      }
      throw new Exception("Could not find performance counter " + 
          "instance name for current process. This is truly strange ...");
    }
