    bool IsValid()
    {
        foreach (Control c in errorProvider1.ContainerControl.Controls)
            if (errorProvider1.GetError(c) != "")
                return false;
        return true;
    }
