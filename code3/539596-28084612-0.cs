                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
             dt.Columns.Add("customerid", typeof(string));
             dt.Columns.Add("contactname", typeof(string));
                dt.Load(reader);
                comboBox1.ValueMember = "customerid";
                comboBox1.DisplayMember = "contactname";
                comboBox1.DataSource = dt;
                conn.Close();
