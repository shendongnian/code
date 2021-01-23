    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows.Forms;
    using System.Windows.Threading;
	private readonly Dispatcher _currentDispatcher = Dispatcher.CurrentDispatcher;
	private delegate void ReportingSchedulerFinishedDelegate();
	private void btRunReport_Click(object sender, EventArgs e)
	{
		btRunReport.Enabled = false;
		btRunReport.Text = "Processing..";
		var thread = new Thread(RunReportScheduler);
		thread.Start();
	}
	private void InitializeGridView()
	{
		// Whatever you need to do here
	}
	private void RunReportScheduler()
	{
		Process p = new Process();
		p.StartInfo.FileName = @"\\fileserve\department$\ReportScheduler_v3.exe";
		p.StartInfo.Arguments = "12";
		p.Start();
		p.WaitForExit();
		_currentDispatcher.BeginInvoke(new ReportingSchedulerFinishedDelegate(ReportingSchedulerFinished), DispatcherPriority.Normal);
	}
	private void ReportingSchedulerFinished()
	{
		InitializeGridView();
		btRunReport.Enabled = true;
		btRunReport.Text = "Start";
	}
