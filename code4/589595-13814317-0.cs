		private void RtbDocKeyDown(object sender, KeyEventArgs e)
	    {
			if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
			{
				DataFormats.Format df = DataFormats.GetFormat(DataFormats.Bitmap);
				StringCollection strcollect = Clipboard.GetFileDropList();
				Image image= Image.FromFile(strcollect[0]);
				Clipboard.Clear();
				Clipboard.SetImage(image);
				if (Clipboard.ContainsImage())
				{
					rtbBody.Paste(df);
					e.Handled = true;
					Clipboard.Clear();
				}
			}
