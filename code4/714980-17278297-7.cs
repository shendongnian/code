        if (control is TableRow)
        {
            var newControl = control.FindDescendants<Label>()
                .Where(ctl=>ctl.ID =="StartDate")
                .FirstOrDefault();
            if (newControl != null)
            {
              
                startDate = newControl.Text;
                
            }
        }
