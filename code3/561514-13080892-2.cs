		//nothing fancy here
		public MainWindow()
		{
			Start = new Coordinates();
			End = new Coordinates();
			DataContext = this;
			InitializeComponent();
		}
		//Start Dependency Property
		public Coordinates Start
		{
			get { return (Coordinates)GetValue(StartProperty); }
			set { SetValue(StartProperty, value); }
		}
		public static readonly DependencyProperty StartProperty =
			DependencyProperty.Register("Start", typeof(Coordinates), typeof(MainWindow), new UIPropertyMetadata(null));
		//End Dependency Property
		public Coordinates End
		{
			get { return (Coordinates)GetValue(EndProperty); }
			set { SetValue(EndProperty, value); }
		}
		public static readonly DependencyProperty EndProperty =
			DependencyProperty.Register("End", typeof(Coordinates), typeof(MainWindow), new UIPropertyMetadata(null));
		//--------------------------------------------------
		//Click causes the mouse position stick to Start/End
		//--------------------------------------------------
		bool flag = false;
		private void Canvas_MouseMove(object sender, MouseEventArgs e)
		{
			var p = e.GetPosition(this);
			if(flag) Start = new Coordinates(p.X, p.Y);
			else End = new Coordinates(p.X, p.Y);
		}
		private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
		{
			flag = !flag;
		}
