    private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                DataTable dt = db.getTable("Select * from view_Cust where CustomerNo=" + txtCustomerNo.Text + "");
                if (dt.Rows.Count > 0)
                {
                    Cust_Id = (int)dt.Rows[0]["Cust_ID"];
                    txtCustomerName.Text = dt.Rows[0]["Name"].ToString();
                    DataTable dt1 = db.getTable("Select * from view_CustomerBalance where CustomerNo=" + txtCustomerNo.Text + "");
                    if (dt1.Rows.Count > 0)
                    {
                        txtCustomerBalance.Text = dt1.Rows[0][2].ToString();
                        btnsave.Text = "Update";
                    }
                }
                else
                {
                    MessageBox.Show("Record Not Found...");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            
            }
        }
