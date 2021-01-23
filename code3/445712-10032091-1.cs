    foreach (string interest in interests_Var)
    {
        HtmlInputCheckBox checkBox = (HtmlInputCheckBox)this.FindControl("interest" + interest);
        if (checkBox == null)
            throw new InvalidOperationException("Missing check box for " + interest);
        checkBox.Checked = true;
    }
