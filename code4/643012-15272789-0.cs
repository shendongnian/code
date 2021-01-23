    ListItem listItem = new ListItem();
    this.Brands.Controls.Add((System.Web.UI.Control) listItem);
    listItem.ID = Sitecore.Web.UI.HtmlControls.Control.GetUniqueID("ListItem");
    listItem.Header = name;
    listItem.Value = name;
    listItem.Selected = name == selectedName;
