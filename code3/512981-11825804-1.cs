	string[] data = new string[] {
		"Absecon","Abstracta","Abundantia","Academia","Acadiau","Acamas",
		"Ackerman","Ackley","Ackworth","Acomita","Aconcagua","Acton","Acushnet",
		"Acworth","Ada","Ada","Adair","Adairs","Adair","Adak","Adalberta","Adamkrafft",
		"Adams"
	};
	public Form1()
	{
		InitializeComponent();
	}
	private void comboBox1_TextChanged(object sender, EventArgs e)
	{
		HandleTextChanged();
	}
	private void HandleTextChanged()
	{
		var txt = comboBox1.Text;
		var list = from d in data
				   where d.ToUpper().StartsWith(comboBox1.Text.ToUpper())
				   select d;
		if (list.Count() > 0)
		{
			comboBox1.DataSource = list.ToList();
			//comboBox1.SelectedIndex = 0;
			var sText = comboBox1.Items[0].ToString();
			comboBox1.SelectionStart = txt.Length;
			comboBox1.SelectionLength = sText.Length - txt.Length;
			comboBox1.DroppedDown = true;
			return;
		}
		else
		{
			comboBox1.DroppedDown = false;
			comboBox1.SelectionStart = txt.Length;
		}
	}
	private void comboBox1_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Back)
		{
			int sStart = comboBox1.SelectionStart;
			if (sStart > 0)
			{
				sStart--;
				if (sStart == 0)
				{
					comboBox1.Text = "";
				}
				else
				{
					comboBox1.Text = comboBox1.Text.Substring(0, sStart);
				}
			}
			e.Handled = true;
		}
	}
