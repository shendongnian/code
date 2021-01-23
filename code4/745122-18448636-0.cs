    public void AuthenticateInSharePoint(String url, String login, String password)
        {
            try
            {
                var uri = new Uri(url);
                var uriBuilder = new UriBuilder();
                uriBuilder.Scheme = uri.Scheme;
                uriBuilder.Port = uri.Port;
                uriBuilder.Host = uri.Host;
                uriBuilder.Path = "_forms/default.aspx";
                uriBuilder.Query = String.Format("ReturnUrl={0}", HttpUtility.UrlEncode(uri.LocalPath));
                var request = (HttpWebRequest)HttpWebRequest.Create(uriBuilder.ToString());
                request.ContentType = "application/x-www-form-urlencoded";
                request.AllowAutoRedirect = true;
                var response = (HttpWebResponse)request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var html = reader.ReadToEnd();
                    var doc = new HtmlDocument();
                    doc.LoadHtml(html);
                    foreach (var node in doc.DocumentNode.Descendants("script").ToList())
                        node.Remove();
                    foreach (var node in doc.DocumentNode.Descendants("link").ToList())
                        node.Remove();
                    var form = doc.DocumentNode.Descendants("form").FirstOrDefault();
                    if (form != null)
                    {
                        form.Attributes["action"].Value = uriBuilder.ToString();
                        var script = doc.CreateElement("script");
                        script.InnerHtml = String.Format(@"
                            var input = document.createElement('input');
                            input.setAttribute('type', 'hidden');
                            input.setAttribute('name', 'ctl00$PlaceHolderMain$signInControl$login');
                            input.value = 'Sign In';
                            document.forms[0].appendChild(input);
                            document.getElementById('ctl00_PlaceHolderMain_signInControl_UserName').value=""{0}""; 
                            document.getElementById('ctl00_PlaceHolderMain_signInControl_password').value=""{1}""; 
                            document.forms[0].submit();", login, password);
                        var body = doc.DocumentNode.Descendants("body").FirstOrDefault();
                        if (body != null)
                            body.AppendChild(script);
                    }
                    var builder = new StringBuilder();
                    using (var writer = new StringWriter(builder))
                        doc.Save(writer);
                    return Content(builder.ToString(), response.ContentType);
                }
            }
            catch (Exception e)
            {
                Log.Error(e, "Failed to authenticate user in SharePoint.");
            }
        }
