    private void UpdateEfItem(MamConfiguration_V1 itemFromDb,
        MamConfiguration_V1 itemFromUi)
    {
        itemFromDb.UpdatedDate = DateTime.Now;
        itemFromDb.Description = itemFromUi.Description;
        itemFromDb.StatusId = itemFromUi.StatusId;
        itemFromDb.Name = itemFromUi.Name;
        itemFromDb.NumericTraffic = itemFromUi.NumericTraffic;
        itemFromDb.PercentageTraffic = itemFromUi.PercentageTraffic;
        itemFromDb.Type = itemFromUi.NumericTraffic;
        foreach (var item in itemFromDb.MamConfigurationToBrowser_V1.ToList())
        {
            if (!itemFromUi.MamConfigurationToBrowser_V1.Any(b =>
                b.BrowserID == item.BrowserID)
            {
                mMaMDBEntities.Browsers.DeleteObject(item);
            }
        }
        for (int i = 0; i < itemFromUi.MamConfigurationToBrowser_V1.Count; i++)
        {
            var element = itemFromUi.MamConfigurationToBrowser_V1.ElementAt(i);
            var item = itemFromDb.MamConfigurationToBrowser_V1
                .SingleOrDefault(b => b.BrowserID == element.BrowserID);
            if (item != null)
            {
                // copy properties from element to item
            }
            else
            {
                element.Browser = mMaMDBEntities.Browsers.Single(browserItem =>
                    browserItem.BrowserID == element.BrowserID);
                itemFromDb.MamConfigurationToBrowser_V1.Add(element);
            }
        }
    }
