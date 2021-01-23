     if (precti.Read())
     {
          
          maskedTextBox2.Text = precti.IsDBNull(24) ? 
                                string.Empty : 
                                precti.GetDateTime(24).ToShortDateString(); 
     }
