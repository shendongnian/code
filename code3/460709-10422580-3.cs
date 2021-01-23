    using (OleDbCommand updateCommand = con.CreateCommand()) 
    { 
       updateCommand.CommandType = CommandType.Text;
       updateCommand.CommandText = "update theses set filename = ? where thesisID = ?"; 
       updateCommand.Parameters.Add(new OleDbParameter("", "", ""...));
       updateCommand.Parameters.Add(new OleDbParameter("", "", ""...));
       updateCommand.ExecuteNonQuery(); 
    } 
