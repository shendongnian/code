    Outlook.Folder folder = Application.GetNamespace("MAPI").Folders[1] as Outlook.Folder;
                    Outlook.StorageItem storageItem = folder.GetStorage("ABCDE", Outlook.OlStorageIdentifierType.olIdentifyBySubject);
    Outlook.UserProperty property = null;
    foreach (Outlook.UserProperty p in storageItem.UserProperties)
    {
        if (p.Name == "PropertyName")
            property = p;
    }
    if (property == null)
    {
        property = storageItem.UserProperties.Add("PropertyName", Outlook.OlUserPropertyType.olText, false,                                                                Outlook.OlDisplayType.olUser);
                    }
    property.Value = "my_value_can_contain[brackets]";
    storageItem.Save();
