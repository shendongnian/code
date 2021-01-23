    public partial class DefaultPage : System.Web.UI.Page
    {
        //Comma-delimited list of offers to be used.
        const string Offers = "Contacts.View";
        //Name of cookie to use to cache the consent token. 
        const string AuthCookie = "delauthtoken";
    
        // Initialize the WindowsLiveLogin module.
        static WindowsLiveLogin wll = new WindowsLiveLogin(true);
    
        protected WindowsLiveLogin.ConsentToken Token;
    
        protected string ConsentUrl;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get the consent URL for the specified offers.
            ConsentUrl = wll.GetConsentUrl(Offers);
            
            HttpRequest req = HttpContext.Current.Request;
            HttpCookie authCookie = req.Cookies[AuthCookie];
    
            // If the raw consent token has been cached in a site cookie, attempt to
            // process it and extract the consent token.
            if (authCookie != null)
            {
                string t = authCookie.Value;
                Token = wll.ProcessConsentToken(t);
                getContacts(Token.DelegationToken,Token.LocationID);
                if ((Token != null) && !Token.IsValid())
                {
                    Token = null;
                }
            }
        }
    
        private void getContacts(string token, string lId)
        {
            long intlid = Int64.Parse(lId, System.Globalization.NumberStyles.HexNumber);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(string.Format("https://livecontacts.services.live.com/users/@C@{0}/rest/livecontacts/contacts/", intlid));
            request.UserAgent = "Windows Live Data Interactive SDK";
            request.ContentType = "application/xml; charset=utf-8";
            request.Method = "GET";
            request.Headers.Add("Authorization", "DelegatedToken dt=\"" + token + "\"");
            
            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    //docNav = new XPathDocument(stream);
                    StreamReader reader = new StreamReader(stream);
                  //  var contactStreamReponse = reader.ReadToEnd();
    
                  //  XmlDocument contacts = new XmlDocument();
                  //  contacts.LoadXml(contactStreamReponse);
    
                   
    
                    //Use the document. For example, display contacts.InnerXml.
    
                  //  labelXml.Text = contacts.InnerXml;
    
                    if (CheckBoxList1.Items.Count < 1)
                    {
                        DataSet ds = new DataSet();
                        ds.ReadXml(reader);
                        response.Close();
                        if (ds.Tables["Contact"].Rows.Count > 0)
                        {
                            ArrayList al = new ArrayList();
    
                            for (int intC = 0; intC < ds.Tables["Email"].Rows.Count; intC++)
                            {
                                //Response.Write("FOr instance" + intC);
    
                                //Response.Write(ds.Tables["Email"].Rows[intC]["Address"].ToString());
                                ///Response.Write("<br>");
                                al.Add(ds.Tables["Email"].Rows[intC]["Address"].ToString());
                            }
                            CheckBoxList1.DataSource = al;
                            CheckBoxList1.DataBind();
                           
                        }
    
                    }
                    else
                    {
                        return;
                    }
                }
    
                
            }
        }
