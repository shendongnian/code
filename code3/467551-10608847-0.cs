    try {
        if (!(oc.State == ConnectionState.Open)) {
            oc.Open();
        }
        query = "SELECT DUCKBILL FROM PLATYPUS";
        da = new OracleDataAdapter();
        oCommand = new OracleCommand(query, oc);
        oCommand.Parameters.Add("ABCid", platypusABCID);
        da.SelectCommand = oCommand;
        dt = new OracleDataTable();
        da.Fill(dt);
        return dt;
    } catch (OracleException e) {
        throw new CustomException("Cannot retrieve duckbill", e);   
    }
