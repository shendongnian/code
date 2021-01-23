     var appDomain = System.IO.Directory.GetCurrentDirectory() + "\\AlarmFiles";
                var strPath = Path.Combine(appDomain,
                    "Alarm_" + DateTime.Now.ToString("ddMMyyyy") + Constants.FileType.XmlFile);
                var fi = new FileInfo(strPath);
                if (fi.Exists)
                {
                    try
                    {
                        var xmlString = System.IO.File.ReadAllText(strPath);
                        var serializeAlarmSummary =
                            new SerializeDeserialize<List<AlarmSummary>>();
                        return serializeAlarmSummary.DeserializeData(xmlString);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    
                }
