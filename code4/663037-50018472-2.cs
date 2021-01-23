    [STAThread]
	static void Main(string[] _args)
	{
		ShowSplash();
		MainForm mainForm = new MainForm();
		Application.Run(mainForm);
    }
    private static void ShowSplash()
	{
		Splash sp = new Splash();
		sp.Show();
		Application.DoEvents();
		System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
		t.Interval = 1000;
		t.Tick += new EventHandler((sender, ea) =>
		{
			sp.BeginInvoke(new Action(() =>
			{
				if (sp != null && Application.OpenForms.Count > 1)
				{
					sp.Close();
					sp.Dispose();
					sp = null;
					t.Stop();
					t.Dispose();
					t = null;
				}
			}));
		});
		t.Start();
	}
