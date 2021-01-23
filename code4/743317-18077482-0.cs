    var source = new CancellationTokenSource();
    var token = source.Token;
    var taskA = Task.Factory.StartNew(
    	() => OperationA()
    	);
    var taskAFinished = taskA.ContinueWith(antecedent =>
    	{
    		source.Cancel();
    		return antecedent.Result;
    	});
    
    var taskB = Task.Factory.StartNew(
    	() => OperationB(token), token
    	);
    var taskBFinished = taskB.ContinueWith(antecedent =>
    	{
    		switch (antecedent.Status)
    		{
    			case TaskStatus.RanToCompletion:
    			case TaskStatus.Canceled:
    				return antecedent.Result;
    			case TaskStatus.Faulted:
    				return null;
    		}
    		return null;
    	});
