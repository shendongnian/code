	public partial class MainWin : For
	{
		private Job _job = new Job();
		private void StartButton_Click(object sender, EventArgs e)
		{
			if(!_job.IsRunning)
			{
				_job.StartProcessing();
			}
		}
		
		private void StopButton_Click(object sender, EventArgs e)
		{
			if(_job.IsRunning)
			{			
				_job.StopProcessing();
			}
		}
	}
