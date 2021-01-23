    System.Threading.Thread thread = new System.Threading.Thread((inputList) =>
        {
           foreach (var input in inputList as IEnumerable<int>)
           {
              //Send input
              System.Threading.Thread.Sleep(500);
            }
          });
      thread.Start();
