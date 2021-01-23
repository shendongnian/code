              using (var sw = new StreamWriter(txtOutputFile, true, Encoding.UTF8))
              {
                while (r.Read())
                {
                  
                  var colCount = r.FieldCount;
                  var curCol = 1;
                  var utf8 = new UTF8Encoding();
                  var row = "";
                  if (r[0].GetType() == typeof(SqlString))
                  {
                    SqlString sqlString = r.GetSqlString(0);
                    Byte[] encodedBytes = sqlString.GetNonUnicodeBytes();
                    row = "\"" + utf8.GetString(encodedBytes) + "\"";
                  }
                  else
                  {
                    row = "\"" + r[0].ToString() + "\"";
                  }
                  
                  
                  while (curCol < colCount)
                  {
                    if (r[curCol].GetType() == typeof(SqlString))
                    {
                      SqlString sqlString = r.GetSqlString(curCol);
                      Byte[] encodedBytes = sqlString.GetNonUnicodeBytes();
                      row += ",\"" + utf8.GetString(encodedBytes) + "\"";
                    }
                    else
                    {
                      row += ",\"" + r[curCol].ToString() + "\"";
                    }
                    curCol += 1;
                  }
                  sw.WriteLine(row);
                }
              }
