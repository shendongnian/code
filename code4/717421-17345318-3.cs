                    string dir = @"\\Fabtrol-2\Program Files (x86)\FabTrolBackUp\";
                    string fileName = dir;
                    switch (DateTime.Now.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            fileName += "FT_FabTrol_Sun_Full.BAK";
                            break;
                        case DayOfWeek.Tuesday:
                            fileName += "FT_FabTrol_Mon_Full.BAK";
                            break;
                        case DayOfWeek.Wednesday:
                            fileName += "FT_FabTrol_Tues_Full.BAK";
                            break;
                        case DayOfWeek.Thursday:
                            fileName += "FT_FabTrol_Wed_Full.BAK";
                            break;
                        case DayOfWeek.Friday:
                            fileName += "FT_FabTrol_Thurs_Full.BAK";
                            break;
                        case DayOfWeek.Saturday:
                            fileName += "FT_FabTrol_Fri_Full.BAK";
                            break;
                        case DayOfWeek.Sunday:
                            fileName += "FT_FabTrol_Sat_Full.BAK";
                            break;
                    }
        
                    FileInfo fi = new FileInfo(fileName);
                    if (fi.Exists && DateTime.Now.AddDays(-2) > fi.LastWriteTime.Date)
                    {
                        (new FileInfo(dir + "FT_Trans_Log_Appendedold.BAK")).Delete();
                        Console.WriteLine("Deleted");
                    }
