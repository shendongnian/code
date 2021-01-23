    //Warning: minimal code, no error catching mechanisms included.
    protected string ObscurePassword(object xmlObj)
    {
    	//var xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><main><blah>some value</blah><password>anyvaluehere</password></main>";
    	var xml = xmlObj.ToString();
    	XDocument doc = XDocument.Parse(xml);
        XElement elm = doc.Descendants("password").First();
    	elm.ReplaceWith(new XElement("password", "*****"));
    	var encodedDoc = System.Web.HttpUtility.HtmlEncode(doc.ToString());
    	return encodedDoc;
    }
