    using System.Data;  
    using System.Data.SqlClient;
    using System.Windows.Forms;
... 
        protected void Save_Click(object sender, EventArgs e)
    {
        string connectionstring = WebConfigurationManager.ConnectionStrings["MyDB01"].ConnectionString;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connectionstring;
        SqlCommand cmd = new SqlCommand();
        cmd = new SqlCommand("DS_SSRS_Reports.dbo.DRPinsertPat", con);
        cmd.Parameters.AddWithValue("@NPI", NPI.Text);
        ...
        cmd.Parameters.Add(new SqlParameter("@return_value", SqlDbType.Int));
        cmd.Parameters["@return_value"].Direction = ParameterDirection.ReturnValue;
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        int r = (Convert.ToInt32(cmd.Parameters["@return_value"].Value));
        if (r.Equals(0))
        {
            MessageBox.Show("MRN already exists in DRP database. Patient not entered.");
        }
        else
        {
            MessageBox.Show("Patient successfully added.");
        }
