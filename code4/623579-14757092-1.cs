    {
      var temp = queryPerformer.performQuery(...);
      foo.ExecutionDuration = temp.ExecutionDuration
      foo.CompletionTime = temp.CompletionTime;
      foo.ReturnedMessage = temp.ReturnedMessage;
    }
