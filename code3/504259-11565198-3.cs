    Updatecmd.Parameters.Add("@FIELD1", SQLDbType.VarCHar, 8, "FIELD1");
    Updatecmd.Parameters.Add("@FIELD2", SQLDbType.VarCHar, 8, "FIELD2");
    
    var param = Updatecmd.Parameters.Add("@ID", SqlDbType.Interger, 6, "ID");
    param.SourceVersion = DataRowVersion.Original;
