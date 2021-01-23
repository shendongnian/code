        using (nServiceReferenceCustomers.GetCustomerClient svc = new ServiceReferenceCustomers.GetCustomerClient())
        {
            XmlNode node = svc.GetAllCustomer();
            DataSet ds = new DataSet();
            using (XmlNodeReader reader = new XmlNodeReader(node))
            {
                ds.ReadXml(reader);
            }
        
        
            DataTable table = ds.Tables["Table"];
            DataRow row = table.Rows[0];
            string Lastname= (string) row["lastname"];
            string Firstname= (string) row["firstname"];
            string Middlename= (string) row["middlename "];
    string email= (string) row["emailaddress"];
    string Phone= (string) row["phonenumber"];
        }
