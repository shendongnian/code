    protected void BoxChecked(object sender, EventArgs e)
    {
        try
        {
            int maximumCheck = -1;
            CheckBoxList CheckExpertiseList = (CheckBoxList)sender;
            try {
                maximumCheck = Convert.ToInt32(CheckExpertiseList.CssClass);
            }
            catch { }
            if (maximumCheck > -1)
            {
                if (CheckExpertiseList.Items.Cast<ListItem>().Where(i => (i.Selected == true)).Count() == maximumCheck)
                {
                    CheckExpertiseList.Items.Cast<ListItem>().Where(i => (i.Selected == false)).ToList().ConvertAll(i => i.Enabled = false).ToList();
                }
                else if (CheckExpertiseList.Items.Cast<ListItem>().Where(i => (i.Selected == true)).Count() == maximumCheck - 1)
                    CheckExpertiseList.Items.Cast<ListItem>().Where(i => (i.Selected == false)).ToList().ConvertAll(i => i.Enabled = true).ToList();
            }
        }
        catch { }
    }  
