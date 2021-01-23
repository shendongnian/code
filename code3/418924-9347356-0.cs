       foreach (Control control in cell.Controls)
       {
            // Must use LinkButton here instead of ImageButton
            // if you are having Links (not images) as the command button.
            ImageButton button = control as ImageButton;
            if (button != null && button.CommandName == "Delete")
                // Add delete confirmation
                button.Attributes.Add("onclick","your javascript here");
        }
