    string Query="SELECT Teams.Name as TeamName,Locations.Name as LocationsName,Address ,Address FROM `Teams`,`Locations` WHERE Teams.LocationId=Locations.LocationId;";
    OpenConnection();
    MySqlCommand MysqlCommand=new MySqlCommand(Query,MysqlConnection);
    MysqlReader=MysqlCommand.ExecuteReader();
    while (MysqlReader.Read()) {
      ...
      Team.Size=MysqlReader["Size"].ToString();
      Location.Address=MysqlReader["Address"].ToString();
      Team.Name=MysqlReader["TeamName"].ToString();
      Location.Name=MysqlReader["LocationsName "].ToString();
      ...
    }
