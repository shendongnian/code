    int cout = ds.Tables["TableName"].Rows.Count;
                    if (cout > 0)
                    {
                        if (ds.Tables["TableName"].Rows[cout - 1]["Image"] != DBNull.Value)
                        {
                            var data = (byte[])(ds.Tables["TableName"].Rows[cout - 1]["Image"]);
                            var stream = new MemoryStream(data);
                            pictureBox1.Image = Image.FromStream(stream);
                        }
                        else
                        {
                            pictureBox1.Image = null;
                        }
                    }
 
