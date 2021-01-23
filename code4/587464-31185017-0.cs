    private Item CopyLatestVersion(Item target, Item itemToCopy, string copyOfName)
        {
            var copiedItem = target.Add(copyOfName, new TemplateID(itemToCopy.TemplateID));
            var db = itemToCopy.Database;
            bool sharedFieldsPopulated = false;
            foreach (var lang in itemToCopy.Languages)
            {
                var languageVersionToCopy = 
                    db.GetItem(itemToCopy.ID, lang, Sitecore.Data.Version.Latest);
                if (languageVersionToCopy.Versions.Count == 0)
                {
                    continue;
                }
                var languageVersionCopied = db.GetItem(copiedItem.ID, lang);
                
                //we have to check if there is already version cause when the item was created
                //Sitecore automatically creates a version already with the context language
                if (languageVersionCopied.Versions.Count == 0)
                {
                    languageVersionCopied = languageVersionCopied.Versions.AddVersion();
                }
                languageVersionCopied.Editing.BeginEdit();
                foreach (Sitecore.Data.Fields.Field field in languageVersionToCopy.Fields)
                {
                    if (field.HasValue
                        && (!sharedFieldsPopulated || !field.Shared)
                        && field.Name.Trim() != "")
                    {
                        languageVersionCopied.Fields[field.Name].Value = field.Value;
                    }
                }
                //this doesn't update the edited by field, which we don't want to set to current user 
                //but keep the original updater like in default copy to functionality
                languageVersionCopied.Editing.EndEdit(false, false);
                //during the first iteration we also copy the shared fields afterwards we don't
                sharedFieldsPopulated = true;
            }
            //recursively copying also all children
            foreach (Item child in itemToCopy.Children)
            {
                CopyLatestVersion(copiedItem, child, child.Name);
            }
            return copiedItem;
        }
