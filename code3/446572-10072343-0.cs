    YourControlType ltMetaTags = null;
    Control ctl = this.Parent;
    while (true)
    {
        ltMetaTags = (ControlType)ctl.FindControl("ControlName");
        if (ltMetaTags == null)
        {
            ctl = ctl.Parent;
            if(ctl.Parent == null)
            {
                return;
            }
            continue;
        }
        break;
    }
