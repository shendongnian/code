    foreach (RepeaterItem contact in rptList.Items)
    {
        HtmlInputCheckBox cBox = contact.FindControl("chkteklif") as HtmlInputCheckBox;
        if (cBox != null)
        {
            string a = cBox.Value;
        }
    }
