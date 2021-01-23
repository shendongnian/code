       private void RemovePreviousVersion(Item myItem, bool includeAllLanguages)
        {
            // get the most recent version
            Item currentVersion = myItem.Versions.GetLatestVersion();
            Item[] versions = myItem.Versions.GetVersions(includeAllLanguages);
    
            // loop through the item versions
            foreach(Item itemVersion in versions)
            {
                // remove the version if it is not the most recent
                if (!itemVersion.Version.Number.Equals(currentVersion.Version.Number))
                {
                    itemVersion.Versions.RemoveVersion();
                }
            }
        }
