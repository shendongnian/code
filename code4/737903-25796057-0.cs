    	private void listView_MouseDown(object sender, MouseEventArgs e)
		{
			var info = listView.HitTest(e.X, e.Y);
			var row = info.Item.Index;
			var col = info.Item.SubItems.IndexOf(info.SubItem);
			var value = info.Item.SubItems[col].Text;
			MessageBox.Show(string.Format("R{0}:C{1} val '{2}'", row, col, value));
		}
