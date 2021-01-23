    private void bindGrid()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source = localhost; Initial Catalog = project; Integrated Security= SSPI";
            conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT policeid as [Police ID], password as [Password], email as [Email], nric as [NRIC], fullname as [Full Name], contact as [Contact], address as [Address], location as [Location] From LoginRegisterPolice where pending='pending'", conn);
            da.Fill(ds);
           GVVerify.DataSource = ds;           
           GVVerify.DataBind();
           conn.Close();
        }
