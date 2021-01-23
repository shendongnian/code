    DateTime date;
            string[] formats = { "dd/MM/yyyy", "dd-MM-yyyy", "d/MM/yyyy", "d-MM-yyyy", "yyyy/MM/dd", "yyyy-MM-dd", "yyyy/M/dd", "yyyy-M-dd", "dd/M/yyyy", "dd-M-yyyy" }; //////////if (DateTime.TryParse(textBox10.Text, null, System.Globalization.DateTimeStyles.None, out date))
            if (DateTime.TryParseExact(textBox10.Text, formats, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                using (SqlConnection cn = new SqlConnection(Class1.x))
                {
                    cn.Open();
                    string cm = "select id from item_treasury where dat='" + date.ToString("yyyy-MM-dd") + "' order by id";
                    ///////////****
                    using (SqlCommand cmd = new SqlCommand(cm, cn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read() == true)
                            {
                                if (dr.HasRows == false)
                                {
                                    MessageBox.Show("xxxxxxxxxxxxxxxxxx");
                                    this.Close();
                                }
                                comboBox1.Items.Add(dr[0].ToString());
                            }
                        }
                    }
                }
            }
