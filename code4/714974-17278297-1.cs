        if (control is TableRow)
        {
            var newControl = control.FindDescendants<Label>()
                .Where(ctl=>ctl.ID =="StartDate")
                .FirstOrDefault();
            if (newControl != null)
            {
                Label startControl = newControl as Label;
                startDate = startControl.Text;
                List<DropDownList> allControls = new List<DropDownList>();
                GetControlList<DropDownList>(Page.Controls, allControls )
                foreach (var childControl in allControls )
                {
                //     call for all controls of the page
                }
            }
        }
