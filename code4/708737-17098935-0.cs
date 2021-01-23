    public int InsertValues(Customer customer)
    {
    this.dbConn.Open(); //System.Data.OleDb.OleDbConnection
    
    this.query = "INSERT INTO someTable (ContactFirstName, ContactLastName, Email, Phone) VALUES (@ContactFirstName,@ContactLastName,@Email,@Phone)";
    this.dbComm = new OleDbCommand(this.query, this.dbConn); //System.Data.OleDb.OleDbCommand
    
    //Add parameters
    this.dbComm.Parameters.AddWithValue("@ContactFirstName", customer.ContactFirstName);
    this.dbComm.Parameters.AddWithValue("@ContactLastName", customer.ContactLastName);
    this.dbComm.Parameters.AddWithValue("@Email", customer.Email);
    this.dbComm.Parameters.AddWithValue("@Phone", customer.Phone);
    
    this.dbComm.ExecuteNonQuery();
    
    //--Snip--
    }
