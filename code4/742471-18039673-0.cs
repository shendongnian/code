    private void getAccount()
    {
        var allAccounts = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Accts.txt");
        foreach (var account in allAccounts)
        {
            var pieces = account.Split(new[] {':'});
            MessageBox.Show(string.Format("Username is {0}. \n\nPassword is {1}.", pieces[0], pieces[1]));
        }
    }
