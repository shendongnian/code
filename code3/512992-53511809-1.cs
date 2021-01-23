    	public static string GetText(ComboBox comboBox)
		{
			if (comboBox.InvokeRequired)
			{
				return (string)comboBox.Invoke(new Func<string>(() => GetText(comboBox)));
			}
			lock (comboBox)
			{
				return comboBox.Text;
			}
		}
		public static void SetText(ComboBox comboBox, string text)
		{
			if (comboBox.InvokeRequired)
			{
				comboBox.Invoke(new Action(() => SetText(comboBox, text)));
				return;
			}
			lock (comboBox)
			{
				comboBox.Text = text;
			}
		}
