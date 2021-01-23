    private void GetCheckBoxes()
    {
        foreach (Control ctrl in rolepanel.Controls)
        {
            if (ctrl is CheckBox)
            {
                CheckBox c = ctrl as CheckBox;
                string cText = c.Text;
                // do what you need to do with cText, or checkbox c
            }
        }
    }
