    protected bool ValidateMaisRespProjectText()
        {
            string html = txtJobMainResp.GetHtml(EditorStripHtmlOptions.None);
            XHtmlErrors = new List<string>();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ProhibitDtd = false;
            settings.ValidationType = ValidationType.DTD;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);
            // Create a local reference for validation11.            
            string xhtmlDtdFile = HttpContext.Current.Server.MapPath("DTD/xhtml1-transitional.dtd");
            string newDoctype = string.Format("<!DOCTYPE html SYSTEM \"file://{0}\">", xhtmlDtdFile);
            // add doc type validation + root element to make it valid.
            html = newDoctype + Environment.NewLine + "<html><head><title>title</title></head><body><div>" + html + "</div></body></html>";
            XmlReader reader = XmlReader.Create(new System.IO.StringReader(html), settings);
            try
            {
                while (reader.Read())
                {
                }
            }
            catch (Exception ex)
            {
                XHtmlErrors.Add(ex.Message);
                txtJobMainRespValidator1.IsValid = false;
                txtJobMainRespValidator1.Text = "* The information entered has invalid HTML content. (DEBUG: " + XHtmlErrors.FirstOrDefault() + ")";
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                
            }
            if (XHtmlErrors.Count != 0)
            {
                txtJobMainRespValidator1.IsValid = false;
                txtJobMainRespValidator1.Text = "* The information entered has invalid HTML content. (DEBUG: " + XHtmlErrors.FirstOrDefault() + ")";
            }
            return XHtmlErrors.Count == 0;
        }
    
    private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            XHtmlErrors.Add(string.Format("({0}) {1} - [Line: {2}, Char: {3}]", e.Severity, e.Message, e.Exception.LineNumber, e.Exception.LinePosition));
        }
