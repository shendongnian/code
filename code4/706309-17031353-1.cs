		private void btnReset_Click(object sender, EventArgs e)
		{		
			richTextBox1.SelectAll();
			richTextBox1.SelectionBackColor = Color.White;
			richTextBox1.ScrollToCaret();
		}
		private void btnHighlight_Click(object sender, EventArgs e)
		{
			const int offset = 100;
			for (int i = 0; i < richTextBox1.TextLength; i++)
			{
				richTextBox1.Select(i, 1);
				richTextBox1.SelectionBackColor = Color.LightGray;
				if (i - offset > 0)
					richTextBox1.Select(i - offset, 1);
				else
					richTextBox1.Select(0, 1);
				richTextBox1.ScrollToCaret();
				
				Application.DoEvents();
				System.Threading.Thread.Sleep(50);
			}
		}
