    Microsoft.Office.Interop.Outlook.Application oApp = Globals.ThisAddIn.Application;
    Microsoft.Office.Interop.Outlook.MAPIFolder inboxFolder = oApp.GetNamespace("MAPI").GetDefaultFolder(OlDefaultFolders.olFolderInbox);
    StorageItem storage = inboxFolder.GetStorage("IPM.Configuration.Autocomplete", OlStorageIdentifierType.olIdentifyByMessageClass);
    PropertyAccessor propertyAcc = storage.PropertyAccessor;
    byte[] got = propertyAcc.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x7C090102");
