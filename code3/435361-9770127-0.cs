        public void WriteLine(string msg)
		{
			if (!string.IsNullOrEmpty(textBox.Text))
			{
				msg = string.Format("{0}{1}", Environment.NewLine, msg);
			}
			textBox.AppendText(msg);
		}
