        public void showpictures()
        {
            {
                using (SqlConnection myDatabaseConnection = new SqlConnection(myConnectionString.ConnectionString))
                {
                    myDatabaseConnection.Open();
                    using (SqlCommand SqlCommand = new SqlCommand("Select LastName, Image from Employee where LastName = @a", myDatabaseConnection))
                    {
                        SqlCommand.Parameters.AddWithValue("@a", textBox1.Text);
                        DataSet DS = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(SqlCommand);
                        da.Fill(DS, "Images");
                        var imagesTable = DS.Tables["Images"];
                        var imagesRows = imagesTable.Rows;
                        var count = imagesRows.Count;
                        if (count <= 0)
                            return;
                        var imageColumnValue =
                            imagesRows[count - 1]["Image"];
                        if (imageColumnValue == DBNull.Value)
                            return;
                        var data = (Byte[])imageColumnValue;
                        using (var stream = new MemoryStream(data))
                        {
                            pictureBox1.Image = Image.FromStream(stream);
                        }
                    }
                }
            }
        }
