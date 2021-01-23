    private void button4_Click(object sender, EventArgs e)
    {
       //Set username and password strings
       string usernameString = "username";
       string passwordString = "password";
       //Input in to username field
       var x = webBrowser1.Document.All.GetElementsByName("j_username");
       x[0].InnerText = (usernameString);
       //Input in to password fields
       var y = webBrowser1.Document.All.GetElementsByName("j_password");
       y[0].InnerText = (passwordString);
       //Click the login button
       var s = webBrowser1.Document.All.GetElementsByName("submit");
       s[0].InvokeMember("click");
    }
