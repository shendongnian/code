    var query = from o in this.mJDBDataset.Products
                                where o.ProductStatus == textBox1.Text || o.Karrot == textBox1.Text || o.ProductDetails == textBox1.Text || o.DepositDate == textBox1.Text || o.SellDate == textBox1.Text
                                select o;
                    dataGridView1.DataSource = query.ToList();
                    //Search and Calculate
                    search = textBox1.Text;
                    cnn.Open();
                    string query1 = string.Format("select * from Products where ProductStatus='"+ search+"'");
                    SqlDataAdapter da = new SqlDataAdapter(query1, cnn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Products");
                    SqlDataReader reader;
                    reader = new SqlCommand(query1, cnn).ExecuteReader();
                    List<double> DuePayment = new List<double>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            foreach (DataRow row in ds.Tables["Products"].Rows)
                            {
                                DuePaymentstring.Add(row["DuePayment"].ToString());
                                DuePayment = DuePaymentstring.Select(x => double.Parse(x)).ToList();
                            }
                        }
                        tdp = 0;
                        tdp = DuePayment.Sum();
                        DuePaymentstring.Remove(Convert.ToString(DuePaymentstring.Count));
                        DuePayment.Clear();
                    }
                    cnn.Close();
                    label3.Text = Convert.ToString(tdp + " Due Payment Count: " + DuePayment.Count + " Due Payment string Count: " + DuePaymentstring.Count);
                    tdp = 0;
                    //DuePaymentstring.RemoveRange(0,DuePaymentstring.Count);
                    //DuePayment.RemoveRange(0, DuePayment.Count);
                    //Search and Calculate
  
