    private List<TruckGpsReading> RecursionMethod(List<SSS.ServicesConfig.data.Reading> first,List<TruckGpsReading> second)
            {
                if (first.Count == 0)
                {
                    
                }
                else
                {
                    foreach (var item in first)
                    {
                        //do the work of adding that you where doing..
                        Logging.Log("Starting ProcessGpsFile.ProcessReading 3", "ProcessReading", Apps.RemoteTruckService);
                        var gpsreading = new TruckGpsReading();
                        gpsreading.DateTimeOfReading = reading.DateTimeOfReading;
                        gpsreading.Direction = reading.Direction;
                        gpsreading.DriverNumber = CurrentIniSettings.DriverNumber;
                        gpsreading.Latitude = (float)reading.Latitude;
                        gpsreading.Longitude = (float)reading.Longitude;
                        gpsreading.Speed = reading.Speed;
                        gpsreading.TruckNumber = CurrentIniSettings.TruckNumber;
                        second.Add(gpsreading);
                        first.Remove(item);
                        //you need to break or you will get an invalidoperation exception
                        break;
    
                    }
                    
                    RecursionMethod(first,second);
                }
                return second;
            }
