                using (IDataReader objDataReader = objDB.ExecuteReader(objCMD))
                {
                    while (objDataReader.Read())
                    {
                        DataBaseObject obj = new DataBaseObject();
                        obj = MapObjectToList(objDataReader);
                        ObjectList.Add(obj);
                    }
                    objDataReader.Dispose();
                }
