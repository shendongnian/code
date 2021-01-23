    public Control ParentControl
    {
        get
        {
            Control ctl = this.Parent;
            while (true)
            {
                if (ctl == null) break;
                if (ctl.ID.Equals("parentDIV"))
                {
                    break;
                }
                ctl = ctl.Parent;
            }
            return ctl;
        }
    }
    if(ParentControl != null)
        ParentControl.Visible = true|false;
