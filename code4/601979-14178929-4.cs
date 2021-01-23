    string path = "accounts.xml";
    XmlDocument XMLDoc = new XmlDocument(); // System.Xml.XmlDocument
    XMLDoc.Load(path);
    foreach (XmlNode AccData in XMLDoc.SelectNodes("/response/accounts/account"))
    {
        if (AccData["accountId"] == null)
        {
            continue;
        }
        else
        {
            int AccountId = Convert.ToInt32(AccData["accountId"].InnerText);
            string CompanyName = AccData["companyName"].InnerText;
            string City= AccData["city"].InnerText;
            string Country= AccData["country"].InnerText;
            string Email= AccData["email"].InnerText;
        }
    }
