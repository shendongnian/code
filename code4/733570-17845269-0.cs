        public void noneChecked(object source, ServerValidateEventArgs args)
    {
        GridViewRow gvrow = (GridViewRow)(source as Control).Parent.Parent;
        bool cbnone = ((CheckBox)gvrow.FindControl("cbnone")).Checked;
        bool cbr = ((CheckBox)gvrow.FindControl("cbr")).Checked;
        bool cbx = ((CheckBox)gvrow.FindControl("cbx")).Checked;
        bool cbp = ((CheckBox)gvrow.FindControl("cbp")).Checked;
        bool cbe = ((CheckBox)gvrow.FindControl("cbe")).Checked;
        if ((cbr || cbx || cbp || cbe) && cbnone)
        {
            ((CustomValidator)gvrow.FindControl("vcbnone")).IsValid = false;
            args.IsValid = false;
        }
    }
