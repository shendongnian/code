		private void Form1_Load(object sender, EventArgs e)
		{
			btnResetPosition_Click(sender, e);
		}
		private void btnMoveToUpperLeft_Click(object sender, EventArgs e)
		{
			//Set Panel View to upper-left before moving around buttons
			panel1.VerticalScroll.Value = panel1.VerticalScroll.Value = panel1.VerticalScroll.Minimum;
			panel1.HorizontalScroll.Value = panel1.HorizontalScroll.Value = panel1.HorizontalScroll.Minimum;
			//Move button1 to "upper-left"
			button1.Location = new Point(0, 0);
			//Adjust "static" controls right and down to simulate moving button1
			button2.Location = new Point(button2.Location.X + 200, button2.Location.Y + 200);
			button3.Location = new Point(button3.Location.X + 200, button3.Location.Y + 200);
			//Scroll to show "static" controls in panel
			panel1.VerticalScroll.Value = panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
			panel1.HorizontalScroll.Value = panel1.HorizontalScroll.Value = panel1.HorizontalScroll.Maximum;
		}
		private void btnResetPosition_Click(object sender, EventArgs e)
		{
			//Set Panel View to upper-left before moving around buttons
			panel1.VerticalScroll.Value = panel1.VerticalScroll.Value = panel1.VerticalScroll.Minimum;
			panel1.HorizontalScroll.Value = panel1.HorizontalScroll.Value = panel1.HorizontalScroll.Minimum;
			//Line up all three buttons
			button1.Location = new Point(19, 17);  // 19 and 17 are used so that when panel scrollbars appear, "static" controls appear to stay in the same place
			button2.Location = button1.Location;
			button2.Location = new Point(button1.Location.X, button1.Location.Y + 29);
			button3.Location = button2.Location;
			button3.Location = new Point(button2.Location.X, button2.Location.Y + 29);
		} 
