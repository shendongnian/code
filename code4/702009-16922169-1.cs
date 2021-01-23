    var cancellationTokenSource = new CancellationTokenSource();
    var cancellation = cancellationTokenSource.Token;
    foreach(db in databases)
    {
      
       //create as many ProgressBar instances as databases you want to update
       //check if ProgressBar exist, then return it and reuse, otherwise create new
       ProgressBar pb = new ProgressBar();   
       pb.Maximum = iterations;   
       pb.Dock = DockStyle.Fill;   
       
       Controls.Add(pb);  
       
      //start thread for every database/progress bar
      Task.Create(progressBar => 
      {   
          var start = (ProgressBar)progressBar).Value; //use last value in case of pause
          Parallel.For(start, iterations, 
              new ParallelOptions(){CancellationToken =  cancellation}
          (i, loopState) =>  
          {   
              if (loopState.ShouldExitCurrentIteration)
                    return;
              //perhaps check loopState.ShouldExitCurrentIteration inside worker method
              Thread.SpinWait(50000000); // do work here   
              BeginInvoke((Action)delegate { ((ProgressBar)progressBar).Value++; });   
          });   
       }, 
       pb, cancellation)
       .ContinueWith(task => 
      {
          //to handle exceptions use task.Exception member
          var progressBar = (ProgressBar)task.AsyncState;
          if (!task.IsCancelled)
          {
              //hide progress bar here and reset pb.Value = 0
          }
      }, 
      TaskScheduler.FromCurrentSynchronizationContext() //update UI from UI thread
      ); 
    }
     //To suspend, call 
     cancellationTokenSource.Cancel();
     //To resume - simply call method above again
