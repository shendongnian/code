    _UserName = AUserName;
    // From the DevArtisans:
    String query = "select roleid from ABCrole where ABCid = :ABCID";
    Devart.Data.Oracle.OracleCommand cmd = new Devart.Data.Oracle.OracleCommand(query, con);
    cmd.CommandType = CommandType.Text;
    int _ABCID = GetABCIDForUserName();
    cmd.Parameters.Add("ABCID", _ABCID);
    cmd.Parameters["ABCID"].Direction = ParameterDirection.Input;
    cmd.Parameters["ABCID"].DbType = DbType.String;
    Devart.Data.Oracle.OracleDataReader odr = cmd.ExecuteReader();
    while (odr.Read()) {
      ACurrentUserRoles.Add(odr.GetString(0));
    }
 
