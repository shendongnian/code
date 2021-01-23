		public void SetLabelText(int i)
		{
			myLabel.Text = i.ToString();
			// not sure that this needed, but try:
			myLabel.Invalidate();
		}
