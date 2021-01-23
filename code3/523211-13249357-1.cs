           protected void btnUpload_Click(object sender, EventArgs e)
               {
                var sb = new StringBuilder();
                widget.RenderControl(new HtmlTextWriter(new StringWriter(sb)));
                string setting = sb.ToString();
                string fileLoc = @"D:\Newsample.txt";
                FileStream fs = null;
                if (!File.Exists(fileLoc))
                {
                    using (fs = File.Create(fileLoc))
                    {
                    }
                }
                if (File.Exists(fileLoc))
                {
                    using (StreamWriter sw = new StreamWriter(fileLoc))
                    {
                        sw.Write(setting);
                    }
                }
                if (File.Exists(fileLoc))
                {
                    setting = File.ReadAllText(fileLoc);
                }
                else
                {
                    Response.Write("<script language='javascript'>window.alert('File not found');</script>");
                }
                FileStream st = new FileStream(fileLoc, FileMode.Open);
                byte[] buffer = new byte[st.Length];
                st.Read(buffer, 0, (int)st.Length);
                SqlConnection conn = new SqlConnection("Data Source=dsname;Initial Catalog=test;User ID=test;pwd=password");
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = conn;
                //OpenConnection(conn);
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Files(Data) VALUES(@Data)", conn);
                //string commandText = "INSERT INTO Files VALUES(@Name, @ContentType, ";commandText = commandText + "@Size, @Data)";
                //cmd.CommandText = commandText;
                //cmd.CommandType = CommandType.Text;
                //cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
                //cmd.Parameters.Add("@ContentType", SqlDbType.VarChar, 50);
                //cmd.Parameters.Add("@size", SqlDbType.Int);
                cmd.Parameters.Add("@Data", SqlDbType.VarBinary);
                //cmd.Parameters["@Name"].Value = "name";
                //cmd.Parameters["@ContentType"].Value = "contentType";
                //cmd.Parameters["@size"].Value = 5;
                cmd.Parameters["@Data"].Value = buffer;
                cmd.ExecuteNonQuery();
                SqlCommand command = new SqlCommand("select Data from Files", conn);
                byte[] buffer3 = (byte[])command.ExecuteScalar();
                FileStream fs2 = new FileStream(@"D:\op.txt", FileMode.Create);
                fs2.Write(buffer, 0, buffer.Length);
                fs2.Close();
                st.Close();
                conn.Close();
            }
