    public MainFrom()
		{
			InitializeComponent();
			f = new Form();
			f.Size = panel1.Size;
			f.FormBorderStyle = FormBorderStyle.None;
			f.BackColor = Color.Black;
			f.Opacity = 0.01;
			f.ShowInTaskbar = false;
			f.Show(this);
			f.Click += new System.EventHandler(this.UserClicked);
		}
