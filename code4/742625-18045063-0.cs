	void FormMain_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (backgroundWorkerSimulationRunMany.IsBusy)
		{
			backgroundWorkerSimulationRunMany.CancelAsync();
			e.Cancel = true;
			timerDelayQuit.Start();
		}
			
	}
	private void timerQuitDelay_Tick(object sender, EventArgs e)
	{
		timerDelayQuit.Stop();
		this.Close();
	}
