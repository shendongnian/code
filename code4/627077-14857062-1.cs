    private void BaseForm_Load(object sender, EventArgs e)
    {
        if (!DesignTimeHelper.IsInDesignMode)
        {
            if (!IsUserValid())
            {
                MessageBox.Show("User is not valid");
            }
        }
        else
        {
            MessageBox.Show("Called from VS");
        }
    }
