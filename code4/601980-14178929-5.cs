    dt = new DataTable("Accountdata"); // System.Data.DataTable
    dt.Columns.Add("Account ID");
    dt.Columns.Add("Company Name");
    dt.Columns.Add("City");
    dt.Columns.Add("Country");
    dt.Columns.Add("Email");
    // and so on                            
    dt.Rows.Add(AccountId, CompanyName, City, Country, Email);
