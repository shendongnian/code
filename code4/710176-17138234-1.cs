	using System.Threading;
	using System.Windows.Forms;
	using System;
	namespace ConsoleApplication1
	{
		class Program
		{
			static void Main(string[] args)
			{
				Label label = new Label { Dock = DockStyle.Top };
				Button button = new Button { Text = "||", Dock = DockStyle.Bottom };
				Form form = new Form();
				form.Controls.Add(label);
				form.Controls.Add(button);
				bool @continue = true;
				bool isRunning = true;
				ManualResetEvent run = new ManualResetEvent(true);
				int i = 0;
				form.Load += (s, a) =>
					{
						ThreadPool.QueueUserWorkItem(o =>
							{
								while (@continue)
								{
									run.WaitOne();
									label.Invoke((Action)(() => { label.Text = i++.ToString(); }));
									Thread.Sleep(1000);
								}
							});
					};
				button.Click += (s, a) =>
					{
						isRunning = !isRunning;
						if (isRunning)
							run.Set();
						else
							run.Reset();
						button.Text = isRunning ? "||" : ">>";
					};
				form.Disposed += (s, a) => @continue = false;
				Application.Run(form);
			}
		}
	}
