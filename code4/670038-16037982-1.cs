    public string ToCsv(IEnumerable<Control> controls, bool outputColumnNames = true)
    {
    	var sb = new StringBuilder();
    
    	if (outputColumnNames)
    	{
    		foreach (var textBox in controls.OfType<TextBox>())
    		{
    			sb.Append(textBox.Name);
    			sb.Append(",");
    		}
    
    		foreach (var comboBox in controls.OfType<ComboBox>())
    		{
    			sb.Append(comboBox.Name);
    			sb.Append(",");
    		}
    		sb.Remove(sb.Length - 1, 1);
    	}
    
    	sb.AppendLine();
    
    	foreach (var textBox in controls.OfType<TextBox>())
    	{
    		sb.Append(textBox.Text);
    		sb.Append(",");
    	}
    
    	foreach (var comboBox in controls.OfType<ComboBox>())
    	{
    		sb.Append(comboBox.Text);
    		sb.Append(",");
    	}
    	sb.Remove(sb.Length - 1, 1);
    
    	return sb.ToString();
    }
