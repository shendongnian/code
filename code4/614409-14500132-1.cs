    string _query = "SELECT PC.SN, [User].Name + ' ' + [User].Family as AssignedTo FROM PC LEFT JOIN User ON PC.USERID = User.ID WHERE PC.Type = @Type";
    
    SqlConnection conn = new SqlConnection("YOUR_CONNECTION_STRING");
    SqlCommand cmd = new SqlCommand(_query, connection);
    cmd.Parameters.AddWithValue("Type", AssetTypeCB.SelectedItem.ToString());
    DataTable dt = new DataTable();
    SqlDataAdapter adp = new SqlDataAdapter(cmd);
    adp.Fill(dt);
