    using (var pu = new ProgressBarUpdate(pb, totalCount))
    {
      for (int x = 0; x < totalCount ; x++)
      {
         // operations here 
         pu.UpdateProgress();
    
         Dispatcher.Invoke(DispatcherPriority.Background, new Action(()=>{}));
      }
    }
 
