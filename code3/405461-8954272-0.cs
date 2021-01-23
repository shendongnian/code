    PagesSection pagesSection = (PagesSection)WebConfigurationManager.GetWebApplicationSection("system.web/pages");
    
    foreach (TagPrefixInfo tag in pagesSection.Controls)
    {
        if (tag.TagName == "header")
        {
            UserControl userControl=  (UserControl) Page.LoadControl(tag.Source);
            PlaceHolder1.Controls.Add(userControl);
            break;
        }
    }
