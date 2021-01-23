    if (em.Value == "" || ln.Value == "" || select.Value == "" || fn.Value == "" || pwr.Value == "" || pw.Value == "" || year.Value == "0" || date.Value == "0" || day.Value == "0" )
    {
        panel1.Visible = true;
    }
    else
    {
        DateTime age = new DateTime(Convert.ToInt32(year.Value), Convert.ToInt32(date.Value), Convert.ToInt32(day.Value));
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand("insert into Register values ( '" + em.Value + "','" + ln.Value + "','" + select.Value + "','" + fn.Value + "','" + pwr.Value + "','" + age + "','" + pw.Value + "')", con);
        cmd.ExecuteNonQuery();
        con.Close();   
    }
