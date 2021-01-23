    string _query = "SELECT PC.SN, Users.Name + ' ' + Users.Family as AssignedTo FROM PC LEFT JOIN Users ON PC.USERID = Users.ID WHERE PC.Type = @Type";
    
    SqlConnection conn = new SqlConnection("YOUR_CONNECTION_STRING");
    SqlCommand cmd = new SqlCommand(_query, connection);
    cmd.Parameters.AddWithValue("Type", AssetTypeCB.SelectedItem.Value);
    DataTable dt = new DataTable();
    SqlDataAdapter adp = new SqlDataAdapter(cmd);
    adp.Fill(dt);
