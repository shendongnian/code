      for (int t = 0; t < data.Data.Count(); t = t + 25000)
                                {
                                    var xEle = new XElement("DataCollections",
                                            from emp in data.Data.Skip(t).Take(25000)
                                            select new XElement("DataCollection",
                                                       new XElement("AssetID", emp.AssetID),
                                                       new XElement("DataPointID", emp.DataPointID),
                                                       new XElement("SourceTag", emp.SourceTag),
                                                       new XElement("TimeStep", emp.TimeStep),
                                                       new XElement("RetInterval", emp.RetInterval),
                                                       new XElement("DatapointDate", emp.DatapointDate.ToString()),
                                                       new XElement("DataPointValue", emp.DataPointValue),
                                                       new XElement("DataFlagID", emp.DataFlagID),
                                                       new XElement("DateDataGrabbed", emp.DateDataGrabbed.ToString()),
                                                       new XElement("DateAddedToDB", emp.DateAddedToDB.ToString())
                                            ));
                                    _DataCollectorManager.Services.dataProcessService.BulkAddPIData(xEle);
                                }
