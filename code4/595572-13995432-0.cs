    protected Control RecursiveFindControl(Control targetControl, string findControlId)
        {
            if (targetControl.HasControls())
            {
                foreach(Control childControl in targetControl.Controls)
                {
                    if (childControl.ID == findControlId)
                    {
                        return childControl;
                    }
                    RecursiveFindControl(childControl, findControlId);
                }
            }
            return null;
        }
