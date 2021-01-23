		private void HandleClick(object sender, EventArgs e)
		{
			var btn = sender as Button;
            if (btn != null)
            {
	     		MessageBox.Show(btn.Text);
            }
		}
