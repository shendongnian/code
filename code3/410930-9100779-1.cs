    protected override void Render(HtmlTextWriter writer)
    {
        rbClear.OnClientClicked = String.Format("ClearTree('{0}')", rbClear.ClientID);
        rbDone.OnClientClicked = String.Format("ClearTree('{0}')", rbDone.ClientID);
        base.Render(writer);
    }
