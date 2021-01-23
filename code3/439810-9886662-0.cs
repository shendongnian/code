    foreach (DataRow row in RetailCamDataSet1.Tables["smBranchWorkingDayInfo"].Select("ID=" + convertedBranchID))
                    {
                        var sTime = DateTime.Parse(row["SunFromTime"].ToString());
                        int sHour = sTime.Hour,
                            sMinute = sTime.Minute,
                            sSecond = sTime.Second;
                        var eTime = DateTime.Parse(row["SunToTime"].ToString());
                        int eHour = eTime.Hour,
                            eMinute = eTime.Minute,
                            eSecond = eTime.Second;
                        TimeSpan startTime = new TimeSpan(sHour, sMinute, sSecond);
                        TimeSpan endTime = new TimeSpan(eHour, eMinute, eSecond);
                        TimeSpan timeDifference = new TimeSpan();
                        timeDifference = endTime.Subtract(startTime);
                        double minutes = timeDifference.TotalMinutes;
                        normalCount = minutes / 15;
