                List<DeviceLogData> dlr = new List<DeviceLogData>();
                dlr.Add(new DeviceLogData(1, 1, DateTime.ParseExact("12:51", "HH:mm", System.Globalization.CultureInfo.InvariantCulture)));
                dlr.Add(new DeviceLogData(1, 2, DateTime.ParseExact("10:49", "HH:mm", System.Globalization.CultureInfo.InvariantCulture)));
                dlr.Add(new DeviceLogData(1, 1, DateTime.ParseExact("13:49", "HH:mm", System.Globalization.CultureInfo.InvariantCulture)));
                dlr.Add(new DeviceLogData(1, 1, DateTime.ParseExact("09:49", "HH:mm", System.Globalization.CultureInfo.InvariantCulture)));
                dlr.Add(new DeviceLogData(1, 3, DateTime.ParseExact("09:48", "HH:mm", System.Globalization.CultureInfo.InvariantCulture)));
                dlr.Add(new DeviceLogData(1, 1, DateTime.ParseExact("15:31", "HH:mm", System.Globalization.CultureInfo.InvariantCulture)));
    
                foreach (var item in DeviceLogData.GetRecords())
                {
                    Console.WriteLine(item.Value);
                }
    
                Console.ReadLine();
