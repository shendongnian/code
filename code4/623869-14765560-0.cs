    public static class ControlFinder
    {
        public static Control Find(Control currentControl, string controlName)
        {
            if (currentControl.HasControls() == false) { return null; }
            else
            {
                Control ReturnControl = currentControl.FindControl(controlName);
                if (ReturnControl != null) { return ReturnControl; }
                else
                {
                    foreach (Control ctrl in currentControl.Controls)
                    {
                        ReturnControl = Find(ctrl, controlName);
                        if (ReturnControl != null) { break; }
                    }
                }
                return ReturnControl;
            }
        }
    }
