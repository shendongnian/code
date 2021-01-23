		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listBox1.SelectedItems.Count == 0)
				return;
			int selectedItemIndex = listBox1.SelectedIndex;
			string selectedItemText = listBox1.SelectedItem.ToString();
			// E.g.
			this.Text = selectedItemText;
		}
