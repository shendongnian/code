    private Control FindControl(Control parent, string id)
            {
                if (parent.ID == id)
                    return parent;
    
                if (parent.HasControls())
                {
                    foreach (Control childControl in parent.Controls)
                    {
                
                        if (childControl.ID == id)
                            return childControl;
    
                        if (childControl.HasControls())
                            return FindControl(childControl, id);
                    }
    
                }
                
                return null;
            }
