    private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
    	try
    	{
    		SetPerformanceCounters();		
    		
    		while (!backgroundWorker1.CancellationPending)
    		{
    			SystemStatusprogressbarCPU.Value = (int)(performanceCounterCPU.NextValue());
    			SystemStatuslabelCPU.Text = "CPU: " + SystemStatusprogressbarCPU.Value.ToString(CultureInfo.InvariantCulture) + "%";
    
    			var phav = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
    			var tot = PerformanceInfo.GetTotalMemoryInMiB();
    			var percentFree = ((decimal)phav / tot) * 100;
    			var percentOccupied = 100 - percentFree;
    			SystemStatuslabelRAM.Text = "RAM: " + (percentOccupied.ToString(CultureInfo.InvariantCulture) + "%").Remove(2, 28);
    			SystemStatusprogressbarRAM.Value = Convert.ToInt32((percentOccupied));
                Thread.Sleep(500); //set update frequency at 500ms
    		}
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine(ex);
    	}
    }
    
    private void SetPerformanceCounters()
    {
    	performanceCounterCPU.CounterName = "% Processor Time";
    	performanceCounterCPU.CategoryName = "Processor";
    	performanceCounterCPU.InstanceName = "_Total";
    
    	performanceCounterRAM.CounterName = "% Committed Bytes In Use";
    	performanceCounterRAM.CategoryName = "Memory";
    }
