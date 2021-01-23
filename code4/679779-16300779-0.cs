    protected void GridView1_RowUpdating(Object sender, GridViewUpdateEventArgs e)
    {
        string city = "";
        string designation = "";
    
        foreach (DictionaryEntry entry in e.NewValues)
        {
            if(entry.Key == "City")
            {
                city = entry.Value.ToString();
            }
            if(entry.Key == "Designation")
            {
                designation = entry.Value.ToString();
            }
        }
    
        SqlCommand cmd = new SqlCommand("update Employee_Details set City=@City, Designation=@Designation where UserId=@UserId, con);
        cmd.Parameters.Add("@City");
        cmd.Parameters.Add("@Designation");
        cmd.Parameters.Add("@UserId");
        cmd.Paramters["@City"].Value = city;
        cmd.Paramters["@Designation"].Value = designation;
        cmd.Paramters["@UserId"].Value = userid;
    }
