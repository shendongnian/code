    ClientRepository getMethods = new ClientRepository();
    Client clientToAdd = new Client();
    ....
    private void RegisterButton_Click(object sender, EventArgs e)
    {
        clientToAdd.FirstName = FirstNameTextBox.Text;
        clientToAdd.LastName = LastNameTextBox.Text;
        getMethods.AddClient(clientToAdd);
    }
