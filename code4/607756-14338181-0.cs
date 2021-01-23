    DataTable tblAccess = new DataTable();
    using(var con = new OleDbConnection(@"Provider=Microsoft.Jet.OleDb.4.0;Data Source =" + Server.MapPath("App_Data\\LR Product Database 2000.mdb"))
    using(var da = new OleDbDataAdapter("SELECT CODE, TITLE FROM tblProducts", con))
    { 
        da.Fill(tblAccess);
    }
    
    DataTable tblSqlServer = new DataTable();
    using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["LRVWebsite"].ToString()))
    using(var da = new SqlDataAdapter("SELECT C.CustomerFirstName,C.CustomerLastName, C.CustomerCompany,C.CustomerPosition,C.CustomerCountry,C.CustomerProvince,C.CustomerContact,CP.ActionDate,CP.ProductCode,CP.CustomerEmail FROM tblCustomers C INNER JOIN tblCustomerProducts CP ON C.CustomerEmail = CP.CustomerEmail ORDER BY ActionDate DESC", con))
    { 
        da.Fill(tblSqlServer);
    }
