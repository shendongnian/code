        protected void btnExecute_Click(object sender, EventArgs e)
    {
        //On btn click, call method to execute program and save all files in local path
        GetVideoData();
    }
	protected void GetVideoData()
		{
			string type = "VIDEO_FULL";
			XmlDocument doc;
			XmlElement root;
			// Refactor document creation to its own function
			doc = CreateANewDoc();
            // Refactor root creation to its own function
			root = CreateANewRoot(doc);
			//THE REST OF THE ELEMENTS ARE A UNIQUE CASE FOR EACH VIDEO, THEREFORE SHOULD LOOP INSIDE THE QUERY RESULT SET, PER VIDEO.
			
			// remove the top 100 and fetch everything	
			string sql100 = "SELECT Location, VideoLibraryId, Title, Keywords, IsActive, Description FROM VideoLibrary";
			const string _connStringName = "SanfordVideosConnectionString";
			string dsn = ConfigurationManager.ConnectionStrings[_connStringName].ConnectionString;
			using (SqlConnection conn = new SqlConnection(dsn))
			using (SqlCommand cmd = new SqlCommand(sql100, conn))
			{
				conn.Open();
				SqlDataReader r = cmd.ExecuteReader();
				
				// declare some counters
				int counter = 0;
				int filecounter = 0;
				
				while (r.Read())
				{
				    counter++; // Increment counter
					
					// when you hit 100, write stuff out and reset
					if (counter == 100 )
					{
						filecounter++; // Increment filecounter
						DumpOutFile(doc, filecounter);
						// Reset counter
						counter = 0;
						// Reset doc
						doc = CreateANewDoc();
						root = CreateANewRoot(doc);
					}
					
					//while going through each row with above SQL command, set data to element attributes in doc for each asset
					XmlElement asset = doc.CreateElement("asset");
					asset.SetAttribute("filename", r["Location"].ToString());
					asset.SetAttribute("refid", r["VideoLibraryId"].ToString());
	
					// TODO: NEED ACTUAL FILE LOCATION BEFORE I CAN EXTRACT THE SIZE OF THE FILE ITSELF
					/*create new FileInfo object to get length of existing video file
					FileInfo f = new FileInfo(r["Location"].ToString());
					long f1 = f.Length;         */
	
					//asset.SetAttribute("size", "10");      // TODO: f1.ToString() for static value of 2nd @
					// TODO: NEED ACTUAL FILE LOCATION AGAIN FOR HASH-CODE
					//asset.SetAttribute("hash-code", "10");  //TODO: GetMD5Hash(r["Location"].ToString())
					//setting the type globally for all videos to VIDEO_FULL ensures FLV and MP4 formats
					asset.SetAttribute("type", type);
					root.AppendChild(asset);
	
					XmlElement title = doc.CreateElement("title");
					title.SetAttribute("name", r["Title"].ToString());
					title.SetAttribute("refid", r["VideoLibraryId"].ToString());
					title.SetAttribute("active", r["IsActive"].ToString().ToUpper());
					// TODO: CHECK TO SEE IF VIDEO-FULL-REFID IS CORRECT
					//title.SetAttribute("video-full-refid", r["Location"].ToString() + "-" + r["VideoLibraryId"].ToString());
	
					XmlElement shortDesc = doc.CreateElement("short-description");
					shortDesc.InnerText = GetTrimmedDescription(250, r["Description"].ToString());
					title.AppendChild(shortDesc);
					root.AppendChild(title);
	
					XmlElement longDesc = doc.CreateElement("long-description");
					longDesc.InnerText = GetTrimmedDescription(5000, r["Description"].ToString());
					title.AppendChild(longDesc);
					root.AppendChild(title);
				}
				
				// Dump out whatever is left (handles the remainder after division by 100
				DumpOutFile(doc, filecounter + 1);
			}
			
		}
	
	//Trims long and short descriptions to max size of chars depending on max size (250 for short and 5000 for long)
	public string GetTrimmedDescription(int maxLength, string desc) {
		if (desc.Length > maxLength)
		{
			return desc.Substring(0, (maxLength - 4)) + " ...";
		}
		else
		{
			return desc;
		}
	}
	private XmlDocument CreateANewDoc()
	{
		XmlDocument doc = new XmlDocument();
		XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
		doc.AppendChild(docNode);
		return doc;
	}
	private XmlElement CreateANewRoot(XmlDocument doc)
	{
		string preparer = "AgencyOasis";
	
		//add global elements:
		//create parameters for each attribute in root to be replaced, and append the new root tag to empty XML doc
		XmlElement root = doc.CreateElement("publisher-upload-manifest");
		//root.SetAttribute("publisher-id", tbPublisherID.Text);
		root.SetAttribute("publisher-id", "tbPublisherID.Text");
		root.SetAttribute("preparer", preparer);
		doc.AppendChild(root);
	
		//append notify as child to root, already in doc
		if (!string.IsNullOrEmpty(tbEmail.Text)) {
			XmlElement notify = doc.CreateElement("notify");
			notify.SetAttribute("email", tbEmail.Text);
			root.AppendChild(notify);
		}
		
		return root;
	}
	private void DumpOutFile(XmlDocument doc, int filenumber)
	{
		//TEMPORARY FILE SAVE LOCATION  TODO: SAVE MULTIPLE FILES IN LOCAL FOLDER
		//returns the directory from where the current application domain was loaded 
		//string xmlPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, inputFileName1);
		string xmlPath = Server.MapPath(txtBoxInput.Text + filenumber.ToString());
		XmlTextWriter writer = new XmlTextWriter(xmlPath, null);
		writer.Formatting = Formatting.Indented;
		doc.Save(xmlPath);
	}
