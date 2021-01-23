    var task = myCollection.TryTakeAsync(TimeSpan.FromSeconds(5));
    task.ContinueWith(t => 
    {
      // Don't forget about exceptions...
      var exception = t.Exception;
      if(exception != null) 
      { 
        // handle exception ...
      }
      else 
      {
        var succeeded = t.Result.Item1;
        var item = t.Result.Item2;
        
        // process...
      }
    });
