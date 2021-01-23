    public string Get_Field(SqlConnection con, string Table,string Field,string where)
    {
        
           DataSet RS_Temp = new DataSet();
           SqlDataAdapter DA;
           string SqlStr = "SELECT " &  Field &  " FROM " & Table;
    
           //Add an "If statment" if there is a where condition....
    
           DA = new OleDbDataAdapter(SqlStr, con);
           DA.Fill(RS_Temp, Table_Name);
    
                if (RS_Temp.Tables[Table_Name].Rows.Count == 0)
                {
                    return ("");
                }
                if (System.Convert.IsDBNull(RS_Temp.Tables[Table_Name].Rows[0][0]))
                {
                    return ("");
                }
    
                if (RS_Temp.Tables[Table_Name].Rows.Count != 0)
                {
                    return (RS_Temp.Tables[Table_Name].Rows[0][0].ToString());
                }
                return ("");
            
    }
