    private void comboBox1_TextChanged(object sender, EventArgs e)
    {
    	for (int i = 0; i < table.Rows.Count; i++)
    	{
    		if (table.Rows[i][NameColumn].ToString() == this.comboBox1.Text)
    		{
    			this.comboBox1.SelectedValue = table.Rows[i][IdColumn];
    			break;
    		}
    	}
    }
