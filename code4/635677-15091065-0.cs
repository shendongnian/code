    log.Debug("Update Starts..");
    StringBuilder updateSql = new StringBuilder();
    updateSql.Append("UPDATE STORE SET ");
    updateSql.Append(" LAT = ").Append("'").Append(Latitude).Append("'");
    updateSql.Append(" ,LONG = ").Append("'").Append(Longitude).Append("'");
    updateSql.Append(" ,LOCATION_TYPE = ").Append("'").Append(locationType).Append("'");
    updateSql.Append(" ,UPDATE_TIMESTAMP = ").Append("'").Append(PopulatedDate).Append("'");
    updateSql.Append(" WHERE ");
    updateSql.Append(" STR_ID = ").Append("'").Append(StoreID).Append("'");
    int result =  OracleHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, updateSql.ToString());
    log.Debug("Update Ends.." + result);
    return 1;
 
