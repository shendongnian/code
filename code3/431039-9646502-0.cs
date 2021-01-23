    StringBuilder bld = new StringBuilder();
    if (sdr.HasRows)    
    {    
       while (sdr.Read())    
       {    
          bld.Append(sdr.GetString(0));
          bld.Append(" at ");
          bld.Append(sdr.GetInt32(1));    
        }    
     }
     TextBox1.Text = bld.ToString();
