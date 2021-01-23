    Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
    NameSpace ns = outlookApp.GetNamespace("mapi");
    ns.Logon(Missing.Value, Missing.Value, false, true);
    AddressEntries addressBook = ns.GetGlobalAddressList().AddressEntries;
    AddressEntry testSearch = addressBook["LastName, FirstName"];
    Console.WriteLine("FreeBusy: {0}", testSearch.GetFreeBusy(DateTime.Now, 30, true));
