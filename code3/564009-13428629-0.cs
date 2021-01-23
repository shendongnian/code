    protected void submitBtn_Click(object sender, EventArgs e)
    {
                try
                {
                    string html = parseHtmlToImageSource(editor.Content);
                    byte[] array = new GetBytes(html);
    	    }
                catch (Exception ex)
                {
                    throw ex
                }
    }
    
    private string parseHtmlToImageSource(string html)
    {
                try
                {
                    string modifiedHTML = html;
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(html);
    
                    var srcTags = doc.DocumentNode.SelectNodes("//img");
                    if (srcTags != null)
                    {
                        foreach (var item in doc.DocumentNode.SelectNodes("//img[@src]"))//select only those img that have a src attribute..ahh not required to do [@src] i guess
                        {
                            string value = item.Attributes["src"].Value.ToString();
    
                            if (!(value.Contains("data:image/") && value.IndexOf("base64") > 0))
                            {
                                string extension = Path.GetExtension(item.Attributes["src"].Value.ToString().ToLower());
    
                                if (extension.Contains("."))
                                {
                                    extension = extension.Remove(extension.IndexOf("."), extension.IndexOf(".") + 1);
                                }
    
                                item.Attributes["src"].Value = makeImageSrcData(item.Attributes["src"].Value.ToString(), extension);
    
                                modifiedHTML = modifiedHTML.Replace(value, item.Attributes["src"].Value.ToString());
                            }
                        }
                    }
    
                    //doc.ToString();
    
                    //doc.Save("yourFile");//dont forget to save
    
                    return modifiedHTML;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
    }
    
    
    private string makeImageSrcData(string url, string extension)
    {
                try
                {
                    WebResponse result = null;
                    WebRequest request = WebRequest.Create(url);
    
                    // Get the content
                    result = request.GetResponse();
    
                    Stream rStream = result.GetResponseStream();
                    byte[] rBytes = ReadFully(rStream);
    
                    return "data:image/" + extension + ";base64," + Convert.ToBase64String(rBytes, Base64FormattingOptions.None);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
    }
    
    public static byte[] GetBytes(string str)
    {
    	try
            {
                byte[] bytes = new byte[str.Length * sizeof(char)];
                System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
                return bytes;
    	}
            catch (Exception ex)
            {
                    throw ex;
            }
    }
    
    public static byte[] ReadFully(Stream input)
    {
                try
                {
                    byte[] buffer = new byte[16 * 1024];
                    using (MemoryStream ms = new MemoryStream())
                    {
                        int read;
                        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, read);
                        }
                        return ms.ToArray();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
    }
