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
    				try
                    {
                       return ant.Result;
                    }
                    catch (AggregateException ae)
                    {
                       // Operation was canceled before start if OperationA is short
                       return null;
                    }
    		    case TaskStatus.Faulted:
    				return null;
    		}
    		return null;
    	});
