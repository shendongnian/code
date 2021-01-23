	public partial class Form1 : Form
	{
		SolidBrush color;
		List<List<Point>> _lines;
		Boolean _mouseDown;
		public Form1()
		{
			InitializeComponent();
			_lines = new List<List<Point>>();
			color = new SolidBrush(Color.Black);
			_mouseDown = false;
		}
		private void btnClear_Click(object sender, EventArgs e)
		{
			_lines.Clear();
			pnlCanvas.Invalidate();
		}
		private void pnlCanvas_MouseDown(object sender, MouseEventArgs e)
		{
			_mouseDown = true;
			_lines.Add(new List<Point>());
		}
		private void pnlCanvas_MouseMove(object sender, MouseEventArgs e)
		{
			if (_mouseDown)
			{
				_lines.Last().Add(e.Location);
				pnlCanvas.Invalidate();
			}
		}
		private void pnlCanvas_MouseUp(object sender, MouseEventArgs e)
		{
			_mouseDown = false;
		}
		private void pnlCanvas_Paint(object sender, PaintEventArgs e)
		{
			foreach (var lineSet in _lines)
			{
				if (lineSet.Count > 1)
				{
					e.Graphics.DrawLines(new Pen(color), lineSet .ToArray());
				}	
			}
			
		}
	}
