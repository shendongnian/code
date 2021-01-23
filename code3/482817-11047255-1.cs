            StringBuilder url = new StringBuilder();
            RepositoryLocalObject context = null;
            if (package.GetByName(Package.ComponentName) == null)
                context = (RepositoryLocalObject)engine.GetObject(
                           package.GetByName(Package.PageName));
            else
                context = (RepositoryLocalObject)engine.GetObject(
                           package.GetByName(Package.ComponentName));
            Repository contextPublication = context.ContextRepository;
            _log.Debug("Starting checking the metadata");
            if (contextPublication.Metadata != null)
            {
                ItemFields metadata =
                 new ItemFields(contextPublication.Metadata, contextPublication.MetadataSchema);
                if (metadata.Contains("LoginPage"))
                {
                    _log.Debug("LoginPage metadata field found in " + metadata.ToXml().OuterXml);
                    ComponentLinkField myLoginComponentField = (ComponentLinkField)metadata["LoginPage"];
                    Component loginTarget = myLoginComponentField.Value;
                    
                    UsingItemsFilter filter = new UsingItemsFilter(engine.GetSession())
                    {
                        
                       // InRepository = contextPublication,
                        ItemTypes = new[] { ItemType.Page }
                        
                    };
                    foreach (comm.Page page in loginTarget.GetUsingItems(filter))
                    {
                        if(PublishEngine.IsPublished(page))
                        {
                            url.Append(" url: ").Append(page.PublishLocationUrl);
                        }
                    }
                }
            }
            return url.ToString();
