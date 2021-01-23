    public partial class Form1 : Form
	{
		// Sync object will be used to syncronize threads
		ManualResetEvent syncEvent;
		public Form1()
		{
		}
		private void button1_Click(object sender, EventArgs e)
		{
			// Creeate sync object in unsignalled state
			syncEvent = new ManualResetEvent(false);
			// I like Async model to start background workers
			// That code will utilize threads from the thread pool
			((Action)Process1).BeginInvoke(null, null);
			((Action)Process2).BeginInvoke(null, null);
		}
		public void updateProgressBarValue(int state)
		{
			// InvokeRequired? -> Invoke pattern will prevent UI update from the non UI thread
			if (InvokeRequired)
			{
				// If current thread isn't UI method will invoke into UI thread itself
				Invoke((Action<int>)updateProgressBarValue, state);
				return;
			}
			double val = Convert.ToDouble(state) / 19.0;
			pb.Value = (int)(100 * val);
		}
		public void updateDataGridViewValue(int state)
		{
			if (InvokeRequired)
			{
				Invoke((Action<int>)updateDataGridViewValue, state);
				return;
			}
			dgv.Rows.Add((int)state, (int)state);
		}
		public void Process1()
		{
			for (int i = 0; i < 10; i++)
			{
				// We have InvokeRequired in the methods and don't need any other code to invoke it in UI thread
				updateDataGridViewValue(i);
				updateProgressBarValue(i);
				Thread.Sleep(2000);
			}
			// When thread 1 complete its job we will set sync object to signalled state to wake up thread 2
			syncEvent.Set();
		}
		public void Process2()
		{
			// Thread 2 will stop until sync object signalled
			syncEvent.WaitOne();
			for (int i = 10; i < 20; i++)
			{
				updateProgressBarValue(i);
				updateDataGridViewValue(i);
				Thread.Sleep(2000);
			}
		}
	}
