	public partial class Form1 : Form
	{
		private Timer second = new Timer();
		private int wheelMoves = 0;
		public Form1()
		{
			second.Interval = 1000;
			second.Tick += new EventHandler(second_Tick);
			InitializeComponent();
		}
		void second_Tick(object sender, EventArgs e)
		{
			second.Stop();
			// DoStuff with wheelmoves.
			textBox1.Text = wheelMoves.ToString() + " " + (wheelMoves * wheelMoves).ToString();
			wheelMoves = 0;
		}
		void Form1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// reset the timer.
			second.Stop();
			second.Start();
			// Count the number of times the wheel moved.
			wheelMoves++;
		}
	}
