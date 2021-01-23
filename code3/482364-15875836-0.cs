            obj_data.productid = tempid;
            obj_data.categoryid =int.Parse(cmbcategory.SelectedValue.ToString());
            obj_data.productcode = txtproductcode.Text;
            obj_data.productname = txtproductname.Text;
            obj_data.mqty = decimal.Parse(txtmqty.Text.ToString());
            OleDbCommand mycmd = new OleDbCommand("select * from productmaster where productname=?", new OleDbConnection(Common.cnn));
            BOMaster obj_datan = new BOMaster();
            mycmd.Parameters.Add(new OleDbParameter("productname", txtproductname.Text));
            mycmd.Connection.Open();
            OleDbDataReader myreader = mycmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (myreader.HasRows == true)
            {
                // savestutus = "false";
                MessageBox.Show("Product Name Already Exist", "Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtproductname.Focus();
                return;
            }
            mycmd.Connection.Close();
            ProductDAL obj_dal = new ProductDAL();
            
            if (obj_dal.Save(obj_data))
            {
              
                Clear();
            }
