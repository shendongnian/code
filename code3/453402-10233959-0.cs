    StringBuilder builder = new StringBuilder();
    while (sdr.Read())
    {
        string value = sdr["name"].ToString();
        if(value.Contains("*"))
            builder.Append(value );
    }
    
    this.txtbox2.Text = builder.ToString();
