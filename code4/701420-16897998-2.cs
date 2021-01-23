    using(OleDbConnection con = new OleDbConnection("Provider=MICROSOFT.ACE.OLEDB.12.0; " +
                          "Data Source=|DataDirectory|//Phonebook-db.accdb;" + 
                          "Persist Security Info=True"))
    {
       try
       {
            OleDbCommand cmd = con.CreateCommand();
            ....
       }
    } // <- Here at the closing brace the connectio will be close and disposed 
 
