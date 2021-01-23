    public partial class Form1 : Form
	{
		private int actualCursorY;
		private int lastCursorY;
		private bool isDragged;
		public Form1()
		{
			InitializeComponent();
		}
		private void barRadPanel_MouseDown(object sender, MouseEventArgs e)
		{
			lastCursorY = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)).Y;
			isDragged = true;
		}
		private void barRadPanel_MouseUp(object sender, MouseEventArgs e)
		{
			isDragged = false;
		}
		private void barRadPanel_MouseMove(object sender, MouseEventArgs e)
		{
			if (isDragged)
			{
				actualCursorY = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)).Y;
				mainRadPanel.Location = new Point(mainRadPanel.Location.X, actualCursorY);
				if (lastCursorY != actualCursorY)
				{
					mainRadPanel.Height -= actualCursorY - lastCursorY;
					lastCursorY = actualCursorY;
				}
			}
		}
	}
