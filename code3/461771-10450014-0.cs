    SqlCommand oldcmd = new SqlCommand("SELECT COUNT(*) from dbo.registrar WHERE [MY ID] = @id", conn);
    oldcmd.Parameters.Add("@id", SqlDbType.Int);
    oldcmd.Parameters["@id"].Value = ID;
    if ((int)oldcms.ExecuteScalar() >= 1)
    {
        lblExists.Visible = true;
        lblExists.ForeColor = System.Drawing.Color.Red;
        lblExists.Text = "Oops! Our records show that you have already signed up for this service. Please check your information or contact your administrator for further assistance.";
    }
    else
    {
        lblExists.Visible = false;
    }
