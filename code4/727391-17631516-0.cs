    public class ProcessWithUpdates
    {
      public async Task Run(IProgress<string> progress)
      {
        await Task.Run(() =>
        {
          for (int i = 0; i < 10; i++)
          {
            if (progress != null)
              progress.Report(String.Format("Update {0}", i));
            Thread.Sleep(500);
          }
        });
      }
   }
    // calling code
    ProcessWithProgress pwp = new ProcessWithProgress();
    await pwp.Run(new Progress<string>(pwp_StatusUpdate));
