    System.Web.UI.WebControls.Literal ltMetaTags = null;
    Control ctl = this.Parent;
    while (true)
    {
        ltMetaTags = (System.Web.UI.WebControls.Literal)ctl.FindControl("ltMetaTags");
        if (ltMetaTags == null)
        {
            if(ctl.Parent == null)
            {
                return;
            }
            ctl = ctl.Parent;
            continue;
        }
        break;
    }
