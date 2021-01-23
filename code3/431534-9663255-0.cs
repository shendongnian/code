            string sDate = "19901209";
            string format = "yyyyMMdd";
            System.Globalization.CultureInfo provider = 
                                 System.Globalization.CultureInfo.InvariantCulture;
            DateTime result = DateTime.ParseExact(sDate, format, provider); 
            // result holds wanted DateTime
