    void HashPassword_Click(object sender, EventArgs e)
             {
                if (Page.IsValid)
                {
                   string hashMethod = "";
    
                   if (md5.Checked)
                   {
                      hashMethod = "MD5";
                   }
                   else
                   {
                      hashMethod = "SHA1";
                   }
    
                   string hashedPassword =
                      FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, hashMethod);
    
                   result.Text = "&lt;credentials passwordFormat=\"" + hashMethod +"\"&gt;<br />" +
                      "  &lt;user name=\"" + Server.HtmlEncode(userName.Text) + "\" password=\"" +
                      hashedPassword + "\" /&gt;<br />" + "&lt;/credentials&gt;";
                }
                else
                {
                   result.Text = "There was an error on the page.";
                }
             }
