    protected void btnSubmit_Click(object sender, EventArgs e)
	{
		string URL = "https://en.wikipedia.org/w/api.php?action=query&list=allcategories&acmin=10&acprefix=" + txtKeyword.Text +
			"&acprop=size|hidden&format=xml&aclimit=500&cmtype=subcat";
		//create an xml document and locad it from the web service
		XmlDocument xmlDoc = new XmlDocument();
		//need to indicate a legitimate user againt (not faking from the browser)
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
		request.UserAgent = "My application";
		xmlDoc.Load(request.GetResponse().GetResponseStream());
		XmlNodeList list = xmlDoc.SelectNodes("/api/query/allcategories/c[@subcats>0]");
		ddlCategories.Items.Clear();
		foreach(XmlNode n in list)
		{
			ddlCategories.Items.Add(n.InnerText);
		}
	}
	protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
	{
		string URL = "https://en.wikipedia.org/w/api.php?action=query&list=categorymembers&cmtitle=Category:" + ddlCategories.SelectedItem + "&format=xml&cmlimit=500";
		//create an xml document and locad it from the web service
		XmlDocument xmlDoc = new XmlDocument();
		//need to indicate a legitimate user againt (not faking from the browser)
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
		request.UserAgent = "My application";
		xmlDoc.Load(request.GetResponse().GetResponseStream());
		XmlNodeList Xn = xmlDoc.SelectNodes("/api/query/categorymembers/cm/@title");
			
			
		lstSubCategories.Items.Clear();
		foreach(XmlNode n in Xn)
		{
			lstSubCategories.Items.Add(n.InnerText);
		}
	}
