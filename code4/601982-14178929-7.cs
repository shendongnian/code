    // Forming a DataTable
    dt = new DataTable("Accountdata"); // System.Data.DataTable
    dt.Columns.Add("Account ID");
    dt.Columns.Add("Company Name");
    dt.Columns.Add("City");
    dt.Columns.Add("Country");
    dt.Columns.Add("Email");
    dt.Columns.Add("Enabled");
    // XML Part
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
            // Fill the DataTable line by line
            int AccountId = Convert.ToInt32(AccData["accountId"].InnerText);
            string CompanyName = AccData["companyName"].InnerText;
            string City = AccData["city"].InnerText;
            string Country = AccData["country"].InnerText;
            string Email = AccData["email"].InnerText;
            int Enabled = Convert.ToInt32(AccData["enabled"].InnerText);
            dt.Rows.Add(AccountId, CompanyName, City, Country, Email, Enabled);
        }
    }               
