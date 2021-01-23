    void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        DataContractJsonSerializer ser = null;
        try
        {
            ser = new DataContractJsonSerializer(typeof(User));
            var user = ser.ReadObject(e.Result) as User;
            txbName.Text = "Username: " + user.Username;
            txbFirstName.Text = "FirstName:" + user.FirstName;
            txbSurname.Text ="Surname: " + user.Surname;
            txbEmail.Text = "Email: " + user.Email;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
