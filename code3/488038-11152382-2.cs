    public MainForm()
    {   
			InitializeComponent();
			string[] args = Environment.GetCommandLineArgs();
			foreach (string arg in args)
			{
				if (arg == "TakeOverAllScreens") { TakeOverAllScreens(); }
				if (arg.StartsWith("Screen|"))
				{
					string[] s;
					s = arg.Split('|');
					int xPos, yPos, screenNum;
					int.TryParse(s[1], out xPos);
					int.TryParse(s[2], out yPos);
					this.Left = xPos;
					this.Top = yPos;
					this.StartPosition = FormStartPosition.Manual;
				}
			}
    }
