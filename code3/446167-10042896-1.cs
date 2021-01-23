    struct SystemStatus
    {
    	public int CpuLoad;
    	public decimal OccupiedPercentage;
    }
    
    private void SetPerformanceCounters()
    {
    	performanceCounterCPU.CounterName = "% Processor Time";
    	performanceCounterCPU.CategoryName = "Processor";
    	performanceCounterCPU.InstanceName = "_Total";
    
    	performanceCounterRAM.CounterName = "% Committed Bytes In Use";
    	performanceCounterRAM.CategoryName = "Memory";
    }
    
    private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
    	try
    	{
    		SetPerformanceCounters();		
    		
    		while (!backgroundWorker1.CancellationPending)
    		{
    			SystemStatus status = new SystemStatus();
    			status.CpuLoad = (int)(performanceCounterCPU.NextValue())		
    			
    			var phav = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
    			var tot = PerformanceInfo.GetTotalMemoryInMiB();
    			var percentFree = ((decimal)phav / tot) * 100;
    			status.OccupiedPercentage = 100 - percentFree;
    			
    			backgroundWorker1.ReportProgress(0, status);
    			
    			Thread.Sleep(500); //set update frequency to 500ms
    		}
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine(ex);
    	}
    }
    
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
    	SystemStatus status = e.UserState as SystemStatus;
    	
    	SystemStatusprogressbarCPU.Value = status.CpuLoad;
    	SystemStatuslabelCPU.Text = "CPU: " + Sstatus.CpuLoad.ToString(CultureInfo.InvariantCulture) + "%";
    
    	SystemStatuslabelRAM.Text = "RAM: " + (status.OccupiedPercentage.ToString(CultureInfo.InvariantCulture) + "%").Remove(2, 28);
    	SystemStatusprogressbarRAM.Value = Convert.ToInt32(status.OccupiedPercentage);
    }
