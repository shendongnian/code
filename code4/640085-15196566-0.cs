    try
            {
                con.Open();
                string pass="abc";
                cmd = new SqlCommand("insert into register values('" + txtName.Text + "','" + txtEmail.Text + "','" + txtPhoneNumber.Text + "','" + ddlUserType.SelectedText + "','" + pass + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                 Page.ClientScript.RegisterStartupScript(this.GetType(), "click","alert('Login Successful');");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
