      string Sqlcommand="Select PinNumber from [Your Table Name]
       where
       AccountNumber='"+Combobox.SelectedItem+"' ;
      SqlConnection con = new SqlConnection(ConnectionString);
          string Sqlcommand="Select PinNumber from [Your Table Name]
          where
           AccountNumber='"+Combobox.SelectedItem+"' ;            
            SqlCommand cmd = new SqlCommand(Sqlcommand, con);
            con.Open();
            Object pinnumber = cmd.ExecuteScalar();
            con.Close();            
            if (pinnumber != null)
            {
                LblError.Visible = false;
                LblError.Text = "";
                if (pinnumber .ToString() == TextBox1.Text)
                {
                    Response.Redirect("");
                }
                else if (TypeUser.ToString() == "HR")
                {
                    MessageBox.Show("You have two attempts remaining");
                }
             }
