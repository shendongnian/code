	private void button1_Click(object sender, EventArgs e)
	{
		string orange = "orange";
		foreach (string line in richTexBox1.Lines)
			if (line.Contains(orange))
				textBox1.Text = line.ToString();
	}
