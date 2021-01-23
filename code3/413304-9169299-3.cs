        protected void gridView_DataBound(object sender, EventArgs e)
        {
            // Loop through the Holidays that are bound to the GridView
            var holidays = (IEnumerable<Holiday>)gridView.DataSource;
            for (int i = 0; i < holidays.Count(); i++)
            {
                // Get the row the Holiday is bound to
                GridViewRow row = gridView.Rows[i];
                // Get the PlaceHolder control
                var placeHolder = (PlaceHolder) row.FindControl("countriesPlaceHolder");
                var countryCheckBox = new CheckBox
                                          {
                                              Checked = true,
                                              ID = "auCheckBox",
                                              Text = "Aus",
                                              Enabled = false
                                          };
                placeHolder.Controls.Add(countryCheckBox);
                var editButton = (LinkButton)row.FindControl("editButton");
                editButton.CommandArgument = i.ToString();
                var updateButton = (LinkButton)row.FindControl("updateButton");
                updateButton.CommandArgument = i.ToString();
                updateButton.Visible = false;
            }
        }
        protected void editButton_Click(object sender, EventArgs e)
        {
            LinkButton editButton = (LinkButton) sender;
            int index = Convert.ToInt32(editButton.CommandArgument);
            GridViewRow row = gridView.Rows[index];
            // Get the PlaceHolder control
            LinkButton updateButton = (LinkButton)row.FindControl("updateButton");
            updateButton.Visible = true;
            editButton.Visible = false;
            CheckBox checkbox = (CheckBox)row.FindControl("auCheckBox");
            if (checkbox != null)
            {
                checkbox.Enabled = true;
                // Get value and update
            }
        }
        protected void updateButton_Click(object sender, EventArgs e)
        {
            LinkButton updateButton = (LinkButton)sender;
            int index = Convert.ToInt32(updateButton.CommandArgument);
            GridViewRow row = gridView.Rows[index];
            // Get the PlaceHolder control
            LinkButton editButton = (LinkButton)row.FindControl("updateButton");
            editButton.Visible = true;
            updateButton.Visible = false;
            CheckBox checkbox = (CheckBox)row.FindControl("auCheckBox");
            if (checkbox != null)
            {
                // Get value and update
                checkbox.Enabled = false;
            }
        }
