    if (!read.IsDBNull(3))
    {
      lblInc3.Visible = true;
      txtInc3.Visible = true;
      lblInc3.Text = read["Income3"].ToString();
    }
    
    if (!read.IsDBNull(4))
    {
      lblInc4.Visible = true;
      txtInc4.Visible = true;
      lblInc4.Text = read["Income4"].ToString();
    } 
    if(read.IsDBNull(3) && read.IsDBNull(4))
    {
      txtInc3.Visible = false;
      txtInc4.Visible = false;
    }
