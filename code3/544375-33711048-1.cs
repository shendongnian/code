    public bool roomSelected()
    {
        foreach (RadioButton rb in GroupBox1.Controls)
        {
            if (rb.Checked == true)
            {
                return true;
            }
        }
        return false;
    }
