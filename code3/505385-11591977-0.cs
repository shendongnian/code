    for (int i = 1; i <= comboBox1.SelectedIndex + 1; i++)
    {
    	var tbEaveLength = FindControl("tbEaveLength" + i);
    	if (tbEaveLength.IsEnabled == false)
    	{
    		eaveLength = 0;
    	}
    	else if (tbEaveLength.Text == "")
    	{
    		throw new Exception("EaveLength {i} must have a value");
    	}
    	else if (!double.TryParse(tbEaveLength{i}.Text, out eaveLength{i}))
    	{
    		throw new Exception("EaveLength {i} must be numerical");
    	}
     }
