        private void binging(ComboBox cbo, string sql) {
            SqlDataAdapter da = new SqlDataAdapter();
            if (Utils.variable.con.State == ConnectionState.Closed) Utils.variable.con.Open();
            da.SelectCommand = new SqlCommand(sql, Utils.variable.con);
            DataSet ds = new DataSet();
            da.Fill(ds, "tb");
            cbo.DataSource = ds.Tables["tb"];
            cbo.ValueMember = "ID";
            cbo.DisplayMember = "Name";
            Utils.variable.con.Close();
        }
