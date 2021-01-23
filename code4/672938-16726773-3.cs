	ExchangeService service = this.GetService();
	FolderId folderID = GetPublicFolderID(service, "My Address Book");
	ContactsFolder folder = ContactsFolder.Bind(service, folderID);
	int folderCount = folder.TotalCount;
	var guid       = DefaultExtendedPropertySet.PublicStrings;
	var epdAccount = new ExtendedPropertyDefinition(0x3A00, MapiPropertyType.String);
	var epdCID     = new ExtendedPropertyDefinition(0x3A4A, MapiPropertyType.String);
	var epdCBLN    = new ExtendedPropertyDefinition(guid, "CustomBln", MapiPropertyType.Boolean);
	var epdCDBL    = new ExtendedPropertyDefinition(guid, "CustomDbl", MapiPropertyType.Double);
	var view = new ItemView(folderCount);
	view.PropertySet = new PropertySet(BasePropertySet.FirstClassProperties);
	view.PropertySet.Add(epdAccount);
	view.PropertySet.Add(epdCID);
	view.PropertySet.Add(epdCBLN);
	view.PropertySet.Add(epdCDBL);
	var searchOrFilterCollection = new List<SearchFilter>();
	searchOrFilterCollection.Add(new SearchFilter.IsEqualTo(PropertiesEWS.epdCBLN, true));
	searchOrFilterCollection.Add(new SearchFilter.IsEqualTo(PropertiesEWS.epdAccount, "user"));
	var filter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, searchOrFilterCollection);
	var contacts = service.FindItems(folderID, view);
	foreach (Contact contact in contacts)
	{
		string Account;
		int  CID;
		bool CBLN;
		double CDBL;
		contact.GetLoadedPropertyDefinitions();
		contact.TryGetProperty(epdAccuont, out Account);
		contact.TryGetProperty(epdCID, out CID);
		contact.TryGetProperty(epdCBLN, out CBLN);
		contact.TryGetProperty(epdCDBL, out CDBL);
		Console.WriteLine(String.Format("{0, -20} - {1} - {2}"
										, contact.DisplayName
										, contact.EmailAddresses[EmailAddressKey.EmailAddress1]
										, Account
										, CID
										, CBLN
										, CDBL
								));
	}
