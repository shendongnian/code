	private void SensorThread_DoWork(object sender, DoWorkEventArgs e) 
	{
		int sensor = 1;
		while(!SensorThread.CancellationPending == true) 
		{
			int newSensor;
			lock(this)
			{
				newSensor = ReadSensor(); 
			}
			
			//sensor state changed
			if(newSensor != sensor)
			{
				//sensor was 1 and changed to 0
				if(newSensor==0)
				{
				   scaleTimer.Start(); 
				}
				sensor = newSensor;
			}
			Thread.Sleep(1);
		}
		e.Cancel = true; 
	}     
	private void ScaleThread_DoWork(object sender, DoWorkEventArgs e) 
	{ 
		//sensor blocked 
		//if (sensorstatus == 0) 
		{ 
			lock(this)
			{
				ReadScale(); 
			}
			//SaveWeight(); 
			prevgate = gate; 
			gate = DetermineGate(); 
			lock(this)
			{
				SetOpenDelay(); 
				SetDuration(); 
			}
		  //if gate = 0, this means the weight of meat on scale  
		  //is not in any weight range. Meat runs off the end. 
		  if (gate == 0) 
		  { 
			txtStatus.Invoke(new UpdateStatusCallback(UpdateStatus), new object[] { meatweight.ToString() +  
																				"lbs is out of range"}); 
		  } 
		  else 
		  { 
			lock(this)
			{
			//open gate 
			}
			lock(this)
			{
			//close gate 
			}
		  } 
	  } 
