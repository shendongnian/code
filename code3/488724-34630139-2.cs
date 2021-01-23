	private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (comboBox2.SelectedItem.ToString() == "Dr")
		{
			MessageBox.Show("its dr");
		}
		else
		{
			MessageBox.Show("its cr");
		}
	}
