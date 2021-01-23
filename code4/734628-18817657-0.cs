    private void lstSubjectsFormat(object sender, ListControlConvertEventArgs e)
    {
        // Assuming your class called Employee , and Firstname & Lastname are the fields
        string lastname = ((Employee)e.ListItem).Firstname;
        string firstname = ((Employee)e.ListItem).Lastname;
        e.Value = lastname + " " + firstname;
    }
