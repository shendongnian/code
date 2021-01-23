    public delegate void CallableFunctionDelegate();
    public delegate bool CallableCondition();
	
    public void CallDelegatesRecursively(
                            List<CallableFunctionDelegate> methodsToCall, 
                            List<CallableCondition> conditionsToCall){
        
        var currentDelegate = delegatesToCall[0];
		
        while(conditionsToCall()){
		
            currentDelegate();  // Call current function
            // (Verify that the list is not empty, etc...)
			
            var restOfList = methodsToCall.GetRange(1, methodsToCall.length);
            var restOfConditions = 
                       conditionsToCall.GetRange(1, conditionsToCall.length);
	
            // Call next function in the "hierarchy" / list:
            CallDelegatesRecursively(restOfList, restOfConditions);
        }
    }
