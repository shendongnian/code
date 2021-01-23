        private void Form1_Load(object sender, EventArgs e)
		{
			tabPage2.Enabled = false;
		}
		private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
		{
			if (!e.TabPage.Enabled)
				e.Cancel = true;
		}
