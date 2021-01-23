    bool Validate()
    {
        if (NameEntered.Equals(string.Empty))
        {
            MessageBox.Show("No name has been entered");
            return false;
        }
        return true;
    }
    void CreateUser()
    {
        if (Validate())
        {
            // Run more code
        }
    }
