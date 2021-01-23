    public bool val2()
    {
        foreach (YourCustomUserControlType item in 
            panel1.Controls.OfType<YourCustomUserControlType>())
        {
            ComboBox cb = item.NameOfYourComboBox;
            if (cb.Text == string.Empty)
            {
                // We know one is empty so we must return true.
                return true;
            }
        }
        // We know none are empty so we can return false.
        return false;
    }
