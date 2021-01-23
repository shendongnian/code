    // do webrequest stuff and return raw html
    string html = DemoDoHttpGet(url, cookieContainer);
    // I'm hitting an asp.net page so I have to repeat a bunch of values back to the server
    // key is the "name" attribute of an element i want to find in the html
    // i gathered these manually by watching a normal exchange with fiddler
    var fields = new Dictionary<string, string>();
    fields.Add(System.Web.HttpUtility.UrlDecode("__LASTFOCUS"), string.Empty);
    fields.Add(System.Web.HttpUtility.UrlDecode("__EVENTTARGET"), string.Empty);
    fields.Add(System.Web.HttpUtility.UrlDecode("__EVENTARGUMENT"), string.Empty);
    fields.Add(System.Web.HttpUtility.UrlDecode("__VIEWSTATE"), string.Empty);
    fields.Add(System.Web.HttpUtility.UrlDecode("__EVENTVALIDATION"), string.Empty);
    fields.Add(System.Web.HttpUtility.UrlDecode("ctl00%24ContentPlaceHolder1%24Login1%24LoginButton"), string.Empty);
    // this method searches the html for elements with the given names and updates
    // the value for each item in the field collection with the value sent from the server
    Scraper.GetFieldValues(fields, html);
    /* looks kind of like this
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var names = new List<string>();
            foreach (var ditem in fields)
            {
                names.Add(ditem.Key);
            }
            foreach (var nitem in names)
            {
                // find items, read value
                string xpath = string.Format("//*[@name=\"{0}\"]", (nitem));
                var nodes = doc.DocumentNode.SelectNodes(xpath);
                // if node found read whatever attribute is appropriate,
                // write value back to fields collection
    */
    // here i'm manually providing values for login username/password
    fields.Add(System.Web.HttpUtility.UrlDecode(
        "ctl00%24ContentPlaceHolder1%24Login1%24UserName"), "my@email.aaa");
    fields.Add(System.Web.HttpUtility.UrlDecode(
        "ctl00%24ContentPlaceHolder1%24Login1%24Password"), "mypassword");
    // another webrequest to post back to the server
    var request2 = (HttpWebRequest)WebRequest.Create(url);
    request2.CookieContainer = cookieContainer;
    request2.Method = "POST";
    request2.ContentType = "application/x-www-form-urlencoded";
    var args = new StringBuilder();
    foreach (var item in fields)
    {
        args.Append(System.Web.HttpUtility.UrlEncode(item.Key));
        args.Append("=");
        args.Append(System.Web.HttpUtility.UrlEncode(item.Value));
        args.Append("&");
    }
    using (System.IO.StreamWriter writer = 
        new System.IO.StreamWriter(request2.GetRequestStream()))
    {
        writer.Write(args.ToString().TrimEnd('&'));
    }
    string html;
    using (var response2 = (System.Net.HttpWebResponse)request2.GetResponse())
    using (var rdr2 = new System.IO.StreamReader(response2.GetResponseStream()))
    {
        html = rdr2.ReadToEnd();
    }
