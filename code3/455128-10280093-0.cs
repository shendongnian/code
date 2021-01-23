    try
            {
                this.CreateOrReplaceTable(_TableName, SQL_CREATE_PULICATIONS_TABLE);
          
                if (!DlgParamPublication.alive)
                {
                    break;
                }
                _Command = this.Connection.CreateCommand();
                _Command.CommandText = string.Format(SQL_INSERT_PULICATIONS, _TableName);
                _Command.CommandType = CommandType.Text;
                _Command.BindByName = true;
                _Command.ArrayBindCount = _Publications.Count;
                _Command.Parameters.Add(":ANNEE", OracleDbType.NVarchar2, _Publications.Select(_Item => _Item.Year).ToArray(), ParameterDirection.Input);
                _Command.Parameters.Add(":IDE_PUBLICATION", OracleDbType.NVarchar2, _Publications.Select(_Item => _Item.Pid).ToArray(), ParameterDirection.Input);
                _Command.Parameters.Add(":IDE_TYPE_PUBLICATION", OracleDbType.NVarchar2, _Publications.Select(_Item => _Item.IdePublicationType.ToString().ToLower()).ToArray(), ParameterDirection.Input);
                _Command.Parameters.Add(":IDE_TYPE_TRAVAIL", OracleDbType.NVarchar2, _Publications.Select(_Item => _Item.IdeTypeOfWork.ToString().ToLower()).ToArray(), ParameterDirection.Input);
                _Command.Parameters.Add(":IDE_NIVEAU_ELEMENT_ORG", OracleDbType.NVarchar2, _Publications.Select(_Item => _Item.UserRefType.ToString().ToLower()).ToArray(), ParameterDirection.Input);
                _Command.Parameters.Add(":IDE_ELEMENT_ORG", OracleDbType.NVarchar2, _Publications.Select(_Item => _Item.UserRefValue).ToArray(), ParameterDirection.Input);
                _Command.Parameters.Add(":AUTEUR", OracleDbType.NClob, _Publications.Select(_Item => _Item.Author).ToArray(), ParameterDirection.Input);
                _InsertedCount += _Command.ExecuteNonQuery();
                _Worker.ReportProgress(0, _InsertedCount);
            }
        catch (Exception _Exc)
        {
            ViewModel.DlgParamPublication.Logger.LogException("INSERT PUBLICATIONS", _Exc, false);
        }
        finally
        {
            this.Disconnect();
        }
