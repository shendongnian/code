    public String getFMSCustomerName()
        {
            string[] cols = {"V_CUST_CODE", "V_CUST_NAME"};
    
            ArrayList CustomerList = (ArrayList)db.Select(cols, "table1", " V_STATUS = 'A'", "order by V_CUST_NAME");
    
            //List<CustomerData> cd = new List<CustomerData>();
            XmlDocument doc = new XmlDocument();
    
            XmlNode CustomersNode = doc.CreateElement("Customers");
            doc.AppendChild(CustomersNode);
    
            foreach (DataRow dr in CustomerList)
            {
                //  cd.Add(new CustomerData(dr["V_CUST_CODE"].ToString(), dr["V_CUST_NAME"].ToString()));
                XmlNode customerNode = doc.CreateElement("Customer");
    
                XmlNode V_CUST_CODENode = doc.CreateElement("V_CUST_CODE");
                V_CUST_CODENode.AppendChild(doc.CreateTextNode(dr["V_CUST_CODE"].ToString()));
                customerNode.AppendChild(V_CUST_CODENode);
                XmlNode V_CUST_NAMENode = doc.CreateElement("V_CUST_NAME");
                V_CUST_NAMENode.AppendChild(doc.CreateTextNode(dr["V_CUST_NAME"].ToString()));
                customerNode.AppendChild(V_CUST_NAMENode);
                CustomersNode.AppendChild(customerNode);
            }
            
            return doc.OuterXml;
        }
