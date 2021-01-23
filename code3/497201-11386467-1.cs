        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new SqlConnection(ObjCon.con.ConnectionString))
                {
                    // I assume this was just for testing to show a direct INSERT works when the sproc didn't.
                    // Otherwise, I'd be using replaceable parameters rather than straight text values as that
                    // makes it quite vulnerable to SQL injection attacks. Better yet, make this a sproc as well
                    // and use it rather than client-side SQL.
                    var query =
                        "INSERT INTO NewProduct ([MS], [Date_of_Added], [Invoice_No], [Challan_No], [EnvType], [TypeSize], [Size],[Description], [Qty], [Quality], [PayState], [Balanace_Amount], [PaymentMode], [Cheque_No], [BankDetails], [P_UnitPrice], [P_Price])  VALUES ('"
                        + txtMs.Text + "','" + dtpNewProduct.Value + "','" + txtInvoiceNo.Text + "','"
                        + txtChallanNo.Text + "','" + cboType.Text + "','" + txtTypeSize1.Text + "X" + txtTypeSize2.Text
                        + "','" + txtSize1.Text + "X" + txtSize2.Text + "','" + txtDesc.Text + "','" + nudQty.Value
                        + "','" + nudQuality.Value + "','" + cboPayState.Text + "','" + txtBalAmt.Text + "','"
                        + cboPayMode.Text + "','" + txtChequeNo.Text + "','" + txtBankNameBranch.Text + "','"
                        + txtPUPrice.Text + "','" + txtPPrice.Text + "')";
                    using (var cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                using (var con = new SqlConnection(ObjCon.con.ConnectionString))
                using (var cmd2 = new SqlCommand("StockProc", con))
                {
                    cmd2.CommandType = CommandType.StoredProcedure;
                    //cmd2.Parameters.Add(new SqlParameter("@Date_of_Added", dtpNewProduct.Value));
                    cmd2.Parameters.Add(new SqlParameter("@EnvType", cboType.Text));
                    cmd2.Parameters.Add(new SqlParameter("@TypeSize", txtTypeSize1.Text + "X" + txtTypeSize2.Text));
                    cmd2.Parameters.Add(new SqlParameter("@Size", txtSize1.Text + "X" + txtSize2.Text));
                    cmd2.Parameters.Add(new SqlParameter("@Desc", txtDesc.Text));
                    cmd2.Parameters.Add(new SqlParameter("@Qty", nudQty.Value));
                    cmd2.Parameters.Add(new SqlParameter("@Quality", nudQuality.Value));
                    //http://www.java2s.com/Tutorial/CSharp/0560__ADO.Net/Callstoredprocedureandpassintheparameter.htm
                    //cmd2.Parameters.Add(new SqlParameter("@EnvType", SqlDbType.NVarChar)).Value = cboType.Text;
                    //cmd2.Parameters.Add(new SqlParameter("@TypeSize", SqlDbType.NVarChar)).Value = txtTypeSize1.Text + "X" + txtTypeSize2.Text;
                    //cmd2.Parameters.Add(new SqlParameter("@Size", SqlDbType.NVarChar )).Value=txtSize1.Text + "X" + txtSize2.Text;
                    //cmd2.Parameters.Add(new SqlParameter("@Desc", SqlDbType.Variant)).Value=txtDesc.Text;
                    //cmd2.Parameters.Add(new SqlParameter("@Qty",SqlDbType.Int)).Value= nudQty.Value;
                    //cmd2.Parameters.Add(new SqlParameter("@Quality", SqlDbType.Int)).Value = nudQuality.Value;
                    con.Open();
                    cmd2.ExecuteNonQuery();
                }
                MessageBox.Show("Your Details has been Saved\rThank You", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The Following Error Occurred" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
