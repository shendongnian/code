    public bool val2()
    {
        foreach (Control item in panel1.Controls.OfType<ComboBox>())
        {
            if (item.Text == string.Empty)
            {
                // We know one is empty so we must return true.
                return true;
            }
        }
        // We know none are empty so we can return false.
        return false;
    }
