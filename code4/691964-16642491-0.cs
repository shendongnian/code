    // Call the page and get the generated HTML
    var doc = new HtmlAgilityPack.HtmlDocument();
    HtmlAgilityPack.HtmlNode.ElementsFlags["br"] = HtmlAgilityPack.HtmlElementFlag.Empty;
    doc.OptionWriteEmptyNodes = true;
    try
    {
        var webRequest = HttpWebRequest.Create(pageUrl);
        Stream stream = webRequest.GetResponse().GetResponseStream();
        doc.Load(stream);
        stream.Close();
    }
    catch (System.UriFormatException uex)
    {
        Log.Fatal("There was an error in the format of the url: " + itemUrl, uex);
        throw;
    }
    catch (System.Net.WebException wex)
    {
        Log.Fatal("There was an error connecting to the url: " + itemUrl, wex);
        throw;
    }
	
	//get the div by id and then get the inner text	
	string testDivSelector = @"//div[id='test']";
	var divString = doc.DocumentNode.SelectSingleNode(testDivSelector).InnerHtml.ToString();
