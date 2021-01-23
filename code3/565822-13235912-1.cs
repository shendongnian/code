    public void FormEvents_Loading(object sender, LoadingEventArgs e)
    {
        string[] actionFields = new string[] { "/my:myFields/my:.../my:...", "/my:myFields/my:.../my:...", etc... };
        for (int i = 0; i < actionFields.Length; i++)
        {
            String field = actionFields[i];
            XPathNavigator node = this.MainDataSource.CreateNavigator().SelectSingleNode(field, this.NamespaceManager);
            if (node.Value.ToLower() == "reject")
            {
                XPathNavigator sigNode = this.MainDataSource.CreateNavigator();
                if (this.Signed) //then unsign it
                {
                    for (int ii = 2; ii <= 13; ii++)
                    {
                        try
                        {
                            XPathNavigator xSignedSection = sigNode.SelectSingleNode(String.Format("my:myFields/my:signatures1/my:signatures{0}", ii), this.NamespaceManager);
                            if (xSignedSection.HasChildren)
                            {
                                xSignedSection.MoveToChild(XPathNodeType.Element); xSignedSection.DeleteSelf();
                            };
                        }
                        catch (Exception ex) { };
                    };
                };
            };
        };
    }
