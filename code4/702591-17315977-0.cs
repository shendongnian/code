    DataSet dsWithSomeTable=new DataSet("NameSpace");
    tblTable.TableName="Table";
    dsWithSomeTable.Tables.Add(tblTable);
    
      SqlParameter xml = new SqlParameter
                {
                    ParameterName = "@XML",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = dsWithSomeTable.GetXml()
                };
