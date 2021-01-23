                    try
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO Users(login,password) VALUES ('" + txtLogin.Text + "','" + txtPass.Text+ "');", con);
                        command.ExecuteNonQuery();
                        Response.Redirect("login.aspx");
                    }
                    catch (SqlException)
                    {
                        lblWrongLogin.Text = "Username already exists.";
                    }
