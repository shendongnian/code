        protected void OnPostAlarm(PostAlarm postAlarm) 
        {
           AlarmRecord record = null;
           List<AlarmRecord> recordList = new List<AlarmRecord>();
    
            using(XmlReader reader = XmlReader.Create("test.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "MonitorResponseRecord":
                                record = new AlarmRecord();
                                recordList.Add(record);
                                reader.MoveToAttribute("DisplayName");
                                record.DisplayName = reader.Value;
                                break;
                            case "AlarmName":
                                record.PmAlarm = reader.ReadString();
                                break;
                            case "Parameter1":
                                record.Parameter1 = reader.ReadString();
                                break;
                            case "Parameter2":
                                record.Parameter2 = reader.ReadString();
                                break;
                            case "Parameter3":
                                record.Parameter3 = reader.ReadString();
                                break;
                        }
                    }
                }
            }
