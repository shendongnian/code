                        using (DataSet ds = new DataSet())
                    {
                        ds.ReadXml(FileName);
                        ConfigDataSet.Load(ds.Tables[0].CreateDataReader(), LoadOption.OverwriteChanges, ConfigDataSet.TableName1);
                        ConfigDataSet.Load(ds.Tables[1].CreateDataReader(), LoadOption.OverwriteChanges, ConfigDataSet.TableName2);
                        ConfigDataSet.Load(ds.Tables[2].CreateDataReader(), LoadOption.OverwriteChanges, ConfigDataSet.TableName3);
                        ConfigDataSet.Load(ds.Tables[3].CreateDataReader(), LoadOption.OverwriteChanges, ConfigDataSet.TableName4);
                    }
