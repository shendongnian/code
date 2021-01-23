    _Command = this.Connection.CreateCommand();             
    _Command.CommandText = string.Format(SQL_INSERT_PULICATIONS, _TableName);             _Command.CommandType = CommandType.Text;             
    _Command.BindByName = true;             
    _Command.Parameters.Add(":ANNEE", OracleDbType.NVarchar2, "", ParameterDirection.Input);             _Command.Parameters.Add(":IDE_PUBLICATION", OracleDbType.NVarchar2, "", ParameterDirection.Input);             
    .....
    
    foreach (var _PublicationSub in _Publications)             
    { 
         _Command.Parameters[":ANNEE"].Value = _PublicationSub.Select(_Item => _Item.Year).ToArray();
         ....
    }
