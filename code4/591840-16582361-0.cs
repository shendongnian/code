        protected void Page_Load(object sender, EventArgs e)
        {
        }
        private void OpenCon()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbPrepConnectionString"].ConnectionString.ToString());
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
      
        private void SubmitData()
        {
            OpenCon();
            string sp = "sp_InsertRecord";
            cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            //add parameters...
            cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int));
            cmd.Parameters.Add (new SqlParameter ("@ProductName",SqlDbType .VarChar,50));
            cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Money));
            //set paarameters....
            cmd.Parameters["@Name"].Value = txtName.Text.ToString();
            cmd.Parameters["@UserId"].Value = txtUserId.Text.ToString();
            cmd.Parameters["@ProductName"].Value = txtProductName.Text.ToString();
            cmd.Parameters["@Price"].Value = txtPrice.Text.ToString();
            cmd.ExecuteNonQuery();
            lblMessage.Text = "data inserted successfully";
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SubmitData();
        }
        private void FindData()
        {
            OpenCon();
            string s = "sp_FindRecord";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
            cmd.Parameters["@Id"].Value = txtName.Text.ToString();
            cmd.CommandType = CommandType.StoredProcedure;
            ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds);
            dt = ds.Tables[0];
            currow = 0;
            FillControls();
            
        }
        private void FillControls()
        {
            txtOrderId.Text = dt.Rows[currow].ItemArray[0].ToString();
            txtUserId.Text = dt.Rows[currow].ItemArray[1].ToString();
            txtProductName.Text = dt.Rows[currow].ItemArray[2].ToString();
            txtPrice.Text = dt.Rows[currow].ItemArray[3].ToString();
        }
        protected void btnFind_Click(object sender, EventArgs e)
        {
            FindData();
        }
    }
}'
