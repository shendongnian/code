    // Create a MembershipCreateStatus Status for Reporting...
    MembershipCreateStatus status = new MembershipCreateStatus();
        
    // Username of the account to add...
    string username = "User121";
    // Generate a dynamic Password....
    string password = "P@55W0Rd";
    // Email Address of the User...
    string email = "email@email.com";
    // Password Question of the User...
    string passwordQuestion = "My Password Question?";
    // Password Answer of the User...
    string passwordAnswer = "My Password Answer!";
    try
    {
    Membership.CreateUser(username, password, email, passwordQuestion, passwordAnswer, true, out status);
    }
    catch (Exception ex)
    {
        this.richTextBox1.Text = "Error...\r\n\r\n" + ex.ToString();
    }
    this.richTextBox1.Text = ("Account Creation   : " + status.ToString() + "\r\n"
                                    + "Username is        : " + username + "\r\n"
                                    + "Password is        : " + password + "\r\n"
                                    + "Email              : " + email);
