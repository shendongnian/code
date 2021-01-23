	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Random rnd = new Random();
			
			Rect r1 = new Rect();
			r1.X = rnd.Next(500);
			r1.Y = rnd.Next(500);
			r1.Width = rnd.Next(50,100);
			r1.Height = rnd.Next(50, 100);
			R1 = r1;
			Rect r2 = new Rect();
			r2.X = rnd.Next(500);
			r2.Y = rnd.Next(500);
			r2.Width = rnd.Next(50, 100);
			r2.Height = rnd.Next(50, 100);
			R2 = r2;
			DataContext = this;
		}
		public Rect R1 { get; set; }
		public Rect R2 { get; set; }
	}
