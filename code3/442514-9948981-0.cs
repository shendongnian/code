    public static double Average(List<double> argMachineDataList)
	{
		//First lets handle the case where argMachineDataList is empty.
        // Otherwise we'll return Double.NaN when we divide by zero.
		if(argMachineDataList.Count == 0)
		{
			throw new ArgumentException("argMachineDataList cannot be an empty List.");
		}
		
		//Second we have to assign an initial value to Total, 
		// because there is no guarantee it will be set in the loop. 
		//And since it's a local variable, it will not automatically be set.
		double Total = 0.0;
		
		//Next since Lists are Zero Base indexed, 
		// we'll want to start with n = 0 so we include the first element.
		//We also want the loop to stop before n = argMachineDataList.Count, 
		// or we'll get an ArgumentOutOfRange Exception when trying to access 
		//  argMachineDataList[n] (when n = argMachineDataList.Count).
		for (int n = 0; n < argMachineDataList.Count; n++)
		{
			//Since we want to add the value of argMachineDataList[n] to Total, 
			// we have to change from = to += 
			//   (which is the same as saying Total = Total + argMachineDataList[n]).
			Total += argMachineDataList[n];
		}
		//Lastly, n will be out of scope outside of the for loop. 
		// So we'll use argMachineDataList.Count, to get the number of items.
		return Total / argMachineDataList.Count;
	}
