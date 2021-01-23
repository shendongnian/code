                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                OdbcCommand cmd = new OdbcCommand("insert into students(id,name,img) values(" + txtId.Text + ",'" + txtName.Text + "',?)", con);
                //OdbcParameter param = new OdbcParameter("@img", OdbcType.Image);
                //param.Value = imageDatas;
                //cmd.Parameters.Add(param);
                cmd.Parameters.AddWithValue("@img", imageDatas);
                // cmd.Parameters.AddWithValue("@img", imageDatas);
                cmd.ExecuteNonQuery();
                MessageBox.Show("inserted successfully");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
