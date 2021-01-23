            TextWriter outTextWriter = new StringWriter();
            Server.Execute("Page1.aspx", outTextWriter);
            Server.Execute("Page2.html", outTextWriter);
            string htmlStringToConvert = outTextWriter.ToString();
            outTextWriter.Close();
            // Use the current page URL as base URL
            string baseUrl = ConfigurationManager.AppSettings["baseURL"].ToString(); //HttpContext.Current.Request.Url.AbsoluteUri;
            // Convert the page HTML string to a PDF document in a memory buffer
            byte[] outPdfBuffer = htmlToPdfConverter.ConvertHtml(htmlStringToConvert, baseUrl);
