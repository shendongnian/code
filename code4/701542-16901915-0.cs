    private string lastName;
    public string LastName
    {
        get { return lastName; }
        set
        {
            lastName = value;
            lastNameTextBox.Text = value;
        }
    }
