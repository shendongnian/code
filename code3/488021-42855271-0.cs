		private void txtBox1_KeyUp(object sender, KeyEventArgs e)
		{               
			if (e.KeyCode == Keys.Tab && e.Shift == false) // TAB Key Pressed
			{
			}
			if (e.KeyCode == Keys.Tab && e.Shift == true) // TAB + SHIFT Key Pressed
			{
			}
		}
		Or
		Using this you can identify Any Key is press inside the form
		//Add This code inside the Form_Load Event
		private void Form1_Load(object sender, EventArgs e)
		{
		this.KeyUp += new System.Windows.Forms.KeyEventHandler(KeyPressEvent);
		this.KeyPreview = true;
		}
		//Create this Custom Event
		private void KeyPressEvent(object sender, KeyEventArgs e) 
		{
			if (e.KeyCode == Keys.Tab && e.Shift == false) // TAB Key Pressed
			{
			}
			if (e.KeyCode == Keys.Tab && e.Shift == true) // TAB + SHIFT Key Pressed
			{
			}
		}
