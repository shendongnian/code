        Command.Parameters.AddWithValue("@nationality", nationality); 
        Command.ExecuteNonQuery(); //CALLED HERE First Time
        int success = Command.ExecuteNonQuery(); //CALLED HERE Second Time (This is the one you want)
        if (success > 0)
        {
            Label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#12223");
            Label1.Visible = true;
            Label1.Text = "You have successfully registered";
            Connect.Close();
        }
