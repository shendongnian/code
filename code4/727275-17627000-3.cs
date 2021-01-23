                    while (dr.Read())
                    {
                            type = dr["Type"].ToString();
                            if (type == "admin")
                            {
                                Response.Redirect("administrator.aspx");
                                Response.End();
                            }
                            else if (type == "general")
                            {
                                Response.Redirect("userspage.aspx");
                                Response.End();
                            }
                    }
                    lblMessage.Text = "wrong userid or password";
