       protected void lnkSuggestArticle_Click(object sender, EventArgs e)
    {
        divSuggestion.Visible = true;
        if (Session["__currentCustomer"] == null)
        {
            divEmailAddress.Visible = true;
        }
    }
