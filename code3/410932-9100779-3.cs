    protected override void Render(HtmlTextWriter writer)
    {
        rbClear.OnClientClicked = String.Format("ClearTree('{0}')", rbClear.ClientID);
        base.Render(writer);
    }
