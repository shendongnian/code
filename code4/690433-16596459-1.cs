	string mediaItemPath = "/sitecore/media library/Files/TestDoc";
	string fileName = "TestDoc.xml";
	//get the content db, i.e. master db
	Sitecore.Data.Database contentDB = Sitecore.Context.ContentDatabase ?? Sitecore.Context.Database;
	//get the media file
	MediaItem mi = contentDB.GetItem(mediaItemPath);
	if (mi == null)
		throw new ItemNotFoundException(mediaItemPath);
	if (!mi.Extension.Equals("xml") || !mi.MimeType.Equals("text/xml"))
		throw new MediaException(string.Format("File {0} was not of correct XML format", mediaItemPath));
	//load xml document using media stream
	var xDoc = System.Xml.Linq.XDocument.Load(mi.GetMediaStream());
	////manipulate the xml as required
	////-- update or add new node or whatever
	string nodeName = "Item";
	string nodeValue = string.Format("{0} {1}", "test node ", DateTime.Now.ToString("yyyyMMddhhmmss"));
	xDoc.Element("rootNode")
		.Add(new System.Xml.Linq.XElement(nodeName, nodeValue));
			
	//save the modified document into a stream
	var xmlStream = new System.IO.MemoryStream();
	xDoc.Save(xmlStream);
	
	// Create the options
	var options = new Sitecore.Resources.Media.MediaCreatorOptions
						{
							FileBased = false, // Store the file in the database, not as a file
							IncludeExtensionInItemName = false, // Keep file extension in item name
							KeepExisting = false, // Keep any existing file with the same name
							Versioned = false, // Do not make a versioned template
							Destination = mediaItemPath, // set the path
							Database = contentDB // Set the database
						};
	//Use a security disabler to allow changes
	using (new Sitecore.SecurityModel.SecurityDisabler())
	{
		//save the item back into media library
		Item mediaItem = Sitecore.Resources.Media.MediaManager.Creator.CreateFromStream(xmlStream, fileName, options);
		xmlStream.Dispose();
	}
