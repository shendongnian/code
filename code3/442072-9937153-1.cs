    public partial class Form1 : Form
	{
		Timer _timer = new Timer();
		private readonly static object _lock = new object();
		public Form1()
		{
			InitializeComponent();
			_timer.Tick += delegate { OnTimerTick(); };
			_timer.Interval = 5000;
			_timer.Start();
		}
		private void OnTimerTick()
		{
			new System.Threading.Thread (DoSomething).Start();
		}
		private void DoSomething()
		{
			Console.WriteLine("Before Lock");
			lock(_lock)
			{
				// Do stuff...
				
				Form2 form2 = new Form2();
				form2.ShowDialog();
				
			}
			Console.WriteLine("After Lock");
		}
	}
    
