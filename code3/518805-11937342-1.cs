    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {//Just as an example, I don't ever call the functions to trigger this event
        int ProgressPercent = e.ProgressPercentage;
        object AnyOtherDataReported = e.UserState;
    }
    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
       //Do something when the work has been completed
       //Note: You should always check e.Cancelled and e.Error before attempting to touch the e.Result. I did not put that protection in this example.
       
       object TheResultFrom_DoWork = e.Result;//This is your "map" object
    }
    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
      //object PassedInObject=e.Argument; //This is the argument you sent to RunWorkerAsync
      
    	//Type cast PassedInObject to your correct Type
    	WhateverTypeItIs_YouDidntSay mapname=(WhateverTypeItIs_YouDidntSay)e.Argument
    	
    	//Perform your task
    	object returnvalue=Map.LoadMap(mapname);//This was your varriable called "map"
    	
    	//Assign the result of your task to the return value
    	e.Result=returnvalue;
    }
