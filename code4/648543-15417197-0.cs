     select new ADPerson()
                        {
    
                            AdPersonId = o.AdPersonId,
                            SamAccountName = o.SamAccountName,
                            Description = o.Description,
                            DisplayName = o.DisplayName,
                            UserPrincipalName = o.UserPrincipalName,
                            Enabled = o.Enabled,
                            LastUpdated = o.LastUpdated,
                            OnlineAssetTag = o.OnlineAssetTag,
                            MsdnTypeId = o.MsdnTypeId,
    
                            MsdnTypeModel = new MsdnTypes()
                            {
                             MsdnTypeDescription = c.MsdnTypeDescription
                            },
                            MsdnSubscription = c.MsdnTypeDescription,
    
    
                        };
