    using (SqlConnection conn = new SqlConnection(@"Data Source=SHARKAWY;Initial Catalog=Booking;Persist Security Info=True;User ID=sa;Password=123456"))
    {
        try
        {
            string query = "select FleetName, FleetID from fleets";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            conn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "Fleet");
            cmbTripName.DataSource = ds.Tables["Fleet"];
            cmbTripName.DisplayMember =  "FleetName";
            cmbTripName.ValueMember = "FleetID";
        }
        catch (Exception ex)
        {
            // write exception info to log or anything else
            MessageBox.Show("Error occured!");
        }               
    }
