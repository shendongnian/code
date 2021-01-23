    PageManager pageManager = PageManager.GetManager();
    VersionManager vmanager = VersionManager.GetManager();
    PageNode duplicated = pageManager.GetPageNodes().FirstOrDefault(p => p.Title == "duplicate");
    if (duplicated != null)
    {
        var draft = pageManager.EditPage(duplicated.Page.Id, true);
        string contentBlockTypeName = typeof(ContentBlock).FullName;
    
        PageDraftControl[] contentBlocks = draft.Controls.Where(contentBlock => contentBlock.ObjectType == contentBlockTypeName).ToArray();
        foreach (PageDraftControl contentBlock in contentBlocks)
        {
            Guid contentBlockId = contentBlock.Id;
            //User "SharedContentID" if you are looking up controls which are linked to a shared content block of a specific ID.
            //If you you are trying to locate a specific control by its own ID, use the explicit "ID" property instead of "SharedCotentID"
            if (contentBlock.Properties.Where(prop => prop.Name == "SharedContentID" && prop.Value.ToString() == contentItemIdstr).FirstOrDefault() != null)
            {
                ControlProperty htmlProperty = contentBlock.Properties.Where(prop => prop.Control.Id == contentBlockId && prop.Name == "Html").FirstOrDefault();
                if (htmlProperty != null)
                {
                    if (AppSettings.CurrentSettings.Multilingual)
                    {
                        htmlProperty.GetString("MultilingualValue").SetString(CultureInfo.CurrentUICulture, "New Value");
                    }
                    else
                    {
                    htmlProperty.Value = "New Value";
                    }
                }
            }
        }
        draft = pageManager.SavePageDraft(draft);
        draft.ParentPage.LockedBy = Guid.Empty;
        pageManager.PublishPageDraft(draft);
        pageManager.DeletePageTempDrafts(draft.ParentPage);
                
        //Use the 2 next lines to create  a new version of your page, if you wish.
        //Otherwise the content will be updated on the current page version.
        vmanager.CreateVersion(draft, draft.ParentPage.Id, true);
        vmanager.SaveChanges();
        
        pageManager.SaveChanges();
    }
