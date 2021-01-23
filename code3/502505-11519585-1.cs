     conn.Open();
    
            //SelectCustomerById(int x);
            comboBoxEx1.Items.Clear();
            SqlCommand comm = new SqlCommand("spSelectCustomerByID", conn);
            //comm.Parameters.Add(new SqlParameter("cust_name", cust_name));
            //comm.CommandText = "spSelectCustomerByID";
            comm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
            comm.CommandType = CommandType.StoredProcedure;
            comm.ExecuteNonQuery();
            SqlDataAdapter sdap = new SqlDataAdapter(comm);
            DataSet dset = new DataSet();
            sdap.Fill(dset, "cust_registrations");        
            comboBoxEx1.DataSource = dset;
            comboBoxEx1.DisplayMember = "cust_name";
