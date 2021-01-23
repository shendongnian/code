    public void OnItemCreated(object sender, EventArgs args)
    {
        var createdArgs = Event.ExtractParameter(args, 0) as ItemCreatedEventArgs;
    
        Sitecore.Diagnostics.Assert.IsNotNull(createdArgs, "args");
        if (createdArgs != null)
        {
            Sitecore.Diagnostics.Assert.IsNotNull(createdArgs.Item, "item");
            if (createdArgs.Item != null)
            {
                var item = createdArgs.Item;
    
                // NOTE: you may want to do additional tests here to ensure that the item
                // descends from /sitecore/content/home
                if (item.Parent != null && 
                    item.Parent.TemplateName == "Your Template" &&
                    item.Parent.Children.Count() > 6)
                {
                    // Delete the item, warn user
                    SheerResponse.Alert(
                        String.Format("Sorry, you cannot add more than 6 items to {0}.",
                                          item.Parent.Name), new string[0]);
                    item.Delete();
                }
            }
        }
    }
