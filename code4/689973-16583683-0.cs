    public string LinkOnClientClick
    {
        get; set;
    }
    
    protected override void CreateChildControls()
    {
       LinkButton linkButton = Page.LoadControl(_ascxPath) as LinkButton;
       if (linkButton != null)
       {
             linkButton.Title = LinkText;
             linkButton.TitleUrl = Link.ToString();
             linkButton.OnClientClick = LinkOnClientClick;
             Controls.Add(linkButton);
       }           
    }
