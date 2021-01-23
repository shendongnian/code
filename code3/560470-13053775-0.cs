       int x = 0;
       void dataPanel()
        {
            if (Int32.TryParse(tbDropBranch.SelectedValue.ToString(), out x)) //Check if tbDropBranch.SelectedValue.ToString() is a valid integer
            {
              DataTable dtPanel = dataBinding._valuePanel(Convert.ToInt32(tbDropBranch.SelectedValue.ToString())); // Error in here
              tbDropPanel.DataSource = new BindingSource(dtPanel, null);
              tbDropPanel.DisplayMember = "panelName";
              tbDropPanel.ValueMember = "panelID";
            }
        }
