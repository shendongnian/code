       //check PAPER OK and Toner OK
        private static bool IspaperOK(ManagementBaseObject printer)
        {
            bool PaperOK = true;
            string[] printers = ConfigurationManager.AppSettings["ModelliStampanti"].Trim().Split('#');
            foreach (var property in printer.Properties)
            {
                
                if (property.Name == "DeviceID")
                {
                    var PaperStatus = printer.Properties["PrinterState"].Value.ToString();
                    for (int i = 0; i <= printers.Length - 1; i++)
                    {
                        
                        if (property.Value.ToString() == printers[i].ToString())
                        {     //131072 = Toner Low
                              //1024 = printing
                              //16 = Out of Paper
                              //5 = out of paper
                              //128 - offline(no internet connection)   
                              
                              //this is for out of paper....
                            if ((PaperStatus == "5") ||(PaperStatus == "16"))
                            {
                                PaperOK = false;
                            }
                            //this is for low toner....
                            if (PaperStatus == "131072")
                            {
                                PaperOK = false;
                            }
                        }
                       
                    }
                }
            }
            return PaperOK;
        }
