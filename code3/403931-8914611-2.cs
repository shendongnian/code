    public interface IProgress
	{
		ManualResetEvent syncEvent { get; }
		void updateProgressBarValue(int state);
		void updateDataGridViewValue(int state);
	}
	public partial class Form1 : Form, IProgress
	{
		// Sync object will be used to syncronize threads
		public ManualResetEvent syncEvent { get; private set; }
		public Form1()
		{
		}
		private void button1_Click(object sender, EventArgs e)
		{
			// Creeate sync object in unsignalled state
			syncEvent = new ManualResetEvent(false);
			// I like Async model to start background workers
			// That code will utilize threads from the thread pool
			((Action<IProgress>)Process1).BeginInvoke(this, null, null);
			((Action<IProgress>)Process2).BeginInvoke(this, null, null);
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
		public void Process1(IProgress progress)
		{
			for (int i = 0; i < 10; i++)
			{
				// We have InvokeRequired in the methods and don't need any other code to invoke it in UI thread
				progress.updateDataGridViewValue(i);
				progress.updateProgressBarValue(i);
				Thread.Sleep(2000);
			}
			// When thread 1 complete its job we will set sync object to signalled state to wake up thread 2
			syncEvent.Set();
		}
		public void Process2(IProgress progress)
		{
			// Thread 2 will stop until sync object signalled
			syncEvent.WaitOne();
			for (int i = 10; i < 20; i++)
			{
				progress.updateProgressBarValue(i);
				progress.updateDataGridViewValue(i);
				Thread.Sleep(2000);
			}
		}
	}
