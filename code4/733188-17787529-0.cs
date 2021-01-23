    public int update_method(string ParameterName)
    {
        module c = new module();
        c.DB_Connection();
        int i;
        string QRY = "UPDATE TableName SET Parameter_Name='" + ParameterName + "' WHERE Parameter_Name='" + ParameterName + "'";
         SqlCommand CMD = new SqlCommand(QRY, c.con);
         i = CMD.ExecuteNonQuery();
         return i;
        }
