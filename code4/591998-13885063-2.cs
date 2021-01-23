    protected override void ProcessRecord()
          {
             ProgressRecord myprogress = new ProgressRecord(1, "Testing", "Progress:");
    
              for (int i = 0; i < 100; i++)
              {
                  myprogress.PercentComplete = i;
                  Thread.Sleep(100);
                  WriteProgress(myprogress);
              }
    
                 WriteObject("Done.");
          }
