    var str = new StringBuilder()
    while (reader.Read())
    {
    	for(int i=0; i<reader.FieldCount ; i++)
    	{
    		str.Append(reader[i].ToString());
    		str.Append(" ");
    	}
    	str.Append("<br/>");	
    }
    lblResult.Text = str.ToString()
