    protected void Page_Load(object sender, EventArgs e)
        {
            //string strSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
            //string strLive = "https://www.paypal.com/cgi-bin/webscr";
            string url = ConfigurationManager.AppSettings["PayPalUrl"];
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
    
            //Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
            string strRequest = Encoding.ASCII.GetString(param);
            strRequest += "&cmd=_notify-validate";
            req.ContentLength = strRequest.Length;
   
    
            //Send the request to PayPal and get the response
            StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            streamOut.Write(strRequest);
    
            streamOut.Close();
            StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = streamIn.ReadToEnd();
            streamIn.Close();
    
            if (strResponse == "VERIFIED")
            {
                // strRequest is a long string delimited by '&'
                string[] responseArray = strRequest.Split('&');
    
                List<KeyValuePair<string, string>> lkvp = new List<KeyValuePair<string, string>>();
    
                string[] temp;
    
                // for each key value pair
                foreach (string i in responseArray)
                {
                    temp = i.Split('=');
                    lkvp.Add(new KeyValuePair<string, string>(temp[0], temp[1]));
                }
    
                // now we have a list of key value pairs
                string firstName = string.Empty;
                string lastName = string.Empty;
                string address = string.Empty;
                string city = string.Empty;
                string state = string.Empty;
                string zip = string.Empty;
                string payerEmail = string.Empty;
                string contactPhone = string.Empty;
    
                foreach (KeyValuePair<string, string> kvp in lkvp)
                {
                    switch (kvp.Key)
                    {
                        case "payer_email":
                            payerEmail = kvp.Value.Replace("%40", "@");
                            break;
                        case "first_name":
                            firstName = kvp.Value;
                            break;
                        case "last_name":
                            lastName = kvp.Value;
                            break;
                        case "address_city":
                            city = kvp.Value.Replace("+", " ");
                            break;
                        case "address_state":
                            state = kvp.Value.Replace("+", " ");
                            break;
                        case "address_street":
                            address = kvp.Value.Replace("+", " ");
                            break;
                        case "address_zip":
                            zip = kvp.Value;
                            break;
                        case "contact_phone":
                            contactPhone = kvp.Value;
                            break;
                        default:
                            break;
                    }
                }
    
                string userName = payerEmail;
                string password = Membership.GeneratePassword(8, 0);
    
                MembershipCreateStatus status = new MembershipCreateStatus();
                MembershipUser newUser = Membership.CreateUser(userName, password, userName, null, null, true, out status);
    
                ProfileCommon pc = ProfileCommon.Create(userName) as ProfileCommon;
                pc.Address.PostalCode = zip;
                pc.Address.Address = address;
                pc.Address.City = city;
                pc.Address.State = state;
                pc.Personal.FirstName = firstName;
                pc.Personal.LastName = lastName;
                pc.Contacts.DayPhone = contactPhone;
                pc.Save();
    
                if (status == MembershipCreateStatus.Success)
                {
                    Roles.AddUserToRole(userName, "User");
    
                    //send email to user indicating username and password
                    SendEmailToUser(userName, password, firstName, lastName, payerEmail);
                }
    
                // need to figure out a way to catch unwanted responses here... redirect somehow
            }
            else if (strResponse == "INVALID")
            {
                //log for manual investigation
            }
            else
            {
                //log response/ipn data for manual investigation
            }
        }
