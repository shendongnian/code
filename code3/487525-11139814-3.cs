    // Store the event handlers in private member variables.
    private System.EventHandler selectedEmployeeChanged = new System.EventHandler(this.lbEmployees_SelectedIndexChanged); 
    private void lbProjects_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Declare this outside of try so that we can close it in finally
        DbDataReader reader = null;
        try
        {
            // Remove your event so that updating lbEmployees doesn't cause
            // lbEmployees_SelectedIndexChanged to get fired.
            lbEmployees.SelectedIndexChanged -= selectedEmployeeChanged;
            // Deselect all items in lbEmployees
            lbEmployees.ClearSelected();
            cmd.CommandText = "SELECT ProjectName FROM Projects WHERE ProjectID IN(SELECT ProjectID FROM EmployeeProject WHERE EmpId=(SELECT EmpId FROM Employee WHERE EmpName= '@EmpName')) ORDER BY ProjectID";
            cmd.Parameters.AddWithValue("@EmpName", lbProjects.SelectedItem.ToString());
            reader = cmd.ExecuteReader();
            // For each row returned, find the index of the matching value
            // in lbEmployees and select it.
            while (rdr.Read())
            {
                int index = lbEmployees.FindStringExact(rdr.GetString(0));
                if(index != ListBox.NoMatches)
                {
                    lbEmployees.SetSelected(index, true);
                }
            }
            this.AutoScroll = true;
        }
        finally
        {
            // Ensure that the reader gets closed, even if an exception ocurred
            if(reader != null)
            {
                reader.Close();
            }
            // Ensure that the handler on lbEmployees is re-added,
            // even if an exception was encountered.
            lbEmployees.SelectedIndexChanged += selectedEmployeeChanged;
        }
    }
