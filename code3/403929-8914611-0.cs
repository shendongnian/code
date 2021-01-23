    public partial class Form1 : Form
	{
		ManualResetEvent syncEvent;
		public Form1()
		{
		}
		private void button1_Click(object sender, EventArgs e)
		{
			syncEvent = new ManualResetEvent(false);
			((Action)Process1).BeginInvoke(null, null);
			((Action)Process2).BeginInvoke(null, null);
		}
		public void updateProgressBarValue(int state)
		{
			if (InvokeRequired)
			{
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
				updateDataGridViewValue(i);
				updateProgressBarValue(i);
				Thread.Sleep(2000);
			}
			syncEvent.Set();
		}
		public void Process2()
		{
			syncEvent.WaitOne();
			for (int i = 10; i < 20; i++)
			{
				updateProgressBarValue(i);
				updateDataGridViewValue(i);
				Thread.Sleep(2000);
			}
		}
	}
