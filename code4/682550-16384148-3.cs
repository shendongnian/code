	public partial class Exitform : Form
	{
		private const int CpNocloseButton = 0x200;
		private bool mouseIsDown = false;
		private Point firstPoint;
		public static sbyte contrastvalue = 0;
		public Exitform()
		{
			InitializeComponent();
			this.TopMost = false;
		}
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams myCp = base.CreateParams;
				myCp.ClassStyle = myCp.ClassStyle | CpNocloseButton;
				return myCp;
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void label1_MouseDown(object sender, MouseEventArgs e)
		{
			firstPoint = e.Location;
			mouseIsDown = true;
			//https://stackoverflow.com/questions/3441762/how-can-i-move-windows-when-mouse-down
		}
		private void label1_MouseUp(object sender, MouseEventArgs e)
		{
			mouseIsDown = false;
		}
		private void label1_MouseMove(object sender, MouseEventArgs e)
		{
			if (mouseIsDown)
			{
				// Get the difference between the two points
				int xDiff = firstPoint.X - e.Location.X;
				int yDiff = firstPoint.Y - e.Location.Y;
				// Set the new point
				int x = this.Location.X - xDiff;
				int y = this.Location.Y - yDiff;
				this.Location = new Point(x, y);
			}
		}
		public event Action<int> TrackBarMoved;// << public event to sense if the trackbar is moved
		private void contrast_trackbar_Scroll(object sender, EventArgs e)
		{
			sbyte contrastVal = (sbyte)(this.contrast_trackbar.Value);//local variable just for use in trackbar
			TrackBarMoved(contrast_trackbar.Value);//pull value is trackbar moved
			string trackerbarvalue = Convert.ToString(contrastVal, CultureInfo.CurrentCulture);// convert to string to push to label
			contrastlabel.Text = trackerbarvalue;//actual push to label
			contrastvalue = (sbyte)contrast_trackbar.Value;
		}
	}
