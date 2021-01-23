    private void AddToComboBox()
    {
        cboAccount.Items.Clear();
        foreach (BankAccount person in account)
        {
            //cboAccount.Items.Add(person.GetName());
            cboAccount.Items.Add(person);
        }
    }
