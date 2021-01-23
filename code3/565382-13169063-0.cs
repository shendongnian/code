    StringBuilder strInsertValues = new StringBuilder("VALUES");
    
    your ParsingCode HERE..
    string [] values = line.Split(',');
    strInsertValues.AppendFormat("({0},{1},{2}),", values[0], values[1], values[2]);
    
    end parse
    
    
    using(SqlConnection cn = new SqlConnection(YOUR_CONNECTION_STRING)){
        SqlCommand cmd = cn.CreateCommand;
        cmd.CommandType = SqlCommandType.Text;
        cmd.CommandText = "INSERT INTO TABLE(Column1, Column2, Column3) " + strInsertValues.ToString().SubString(0, strInsertValues.Length);
        cn.Open();
        cmd.ExecuteNonQuery();
    
    }
