        protected List<Control> FindButton(ControlCollection controls, string buttonText)
        {
           List<Control> foundControls = (from c in controls.Cast<Control>() where c is Button && ((Button)c).Text == "Test Button" select c).ToList();
           if (foundControls.Count > 0)
               return foundControls;
           else
           {
               foreach (Control ctrl in controls)
               {
                   if (foundControls.Count == 0)
                       foundControls = FindButton(ctrl.Controls, buttonText);
                   if (foundControls.Count > 0)
                    break;
               }
               return foundControls;
           }
        }
