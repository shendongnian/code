      public class ScheduledAgent : ScheduledTaskAgent
      {
          protected override void OnInvoke(ScheduledTask task)
          {
            //update data
            var tBuilder = new TileBuilder(); // oops, you use code from proj A. 
                                              // So, you have it
                                              // as a reference, And MS thinks that 
                                              // your bgAgent uses forbidden API
                                               
          }
    }
