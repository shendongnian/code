      try
            {
                insertUser.ExecuteNonQuery();
                con6.Close();
                Session["Email"] = textEmailRegister.Text; //User gets logged in
                Response.Redirect("~/UserPages/Default.aspx"); //Send to startpage
            }
            catch (Exception)
            {
                lblErrorRegister.Text = "An error ocurred."; //Otherwise error
            }
