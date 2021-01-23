        public static DateTime ToEn(string fadate)
        {
            if (fadate.Trim() == "") return DateTime.MinValue;
            int[] farsiPartArray = SplitRoozMahSal(fadate);
            return new PersianCalendar().ToDateTime(farsiPartArray[0], farsiPartArray[1], farsiPartArray[2], 0, 0, 0, 0);
        }
 
        private static int[] SplitRoozMahSal(string farsiDate)
        {
            //normalization
            farsiDate = farsiDate.Trim().Replace(@"\", "/").Replace(@"-", "/").Replace(@" ", "/");
            if (!farsiDate.Contains("/"))
            {
                if (farsiDate.Split('/').Length != 2)
                    throw new Exception("usually there should be 2 seperator for a complete date");
            }
            
            int year = 0;
            int month = 0;
            int day = 0;
            int.TryParse(farsiDate.Substring(0, 4), out year);
            if (year == 0)
                throw new Exception("the first 4 character must denots a shamsi year like 1393");
            switch (farsiDate.Length)
            {
                case 10://1389/01/01
                    month = Convert.ToInt32(farsiDate.Substring(5, 2));
                    day = Convert.ToInt32(farsiDate.Substring(8, 2));
                    break;
                case 8://13900421
                    if (!farsiDate.Contains("/"))
                    {
                        month = Convert.ToInt32(farsiDate.Substring(4, 2));
                        day = Convert.ToInt32(farsiDate.Substring(6, 2));
                    }
                    else if (farsiDate[4] == '/' && farsiDate[6] == '/')//1389/1/1
                    {
                        month = Convert.ToInt32(farsiDate.Substring(5, 1));
                        day = Convert.ToInt32(farsiDate.Substring(7, 1));
                    }
                    break;
                case 9://1389/01/1 or //1389/1/01
                    if (farsiDate.Substring(7, 1) == "/")
                    {
                        month = Convert.ToInt32(farsiDate.Substring(5, 2));
                        day = Convert.ToInt32(farsiDate.Substring(8, 1));
                    }
                    else
                    {
                        month = Convert.ToInt32(farsiDate.Substring(5, 1));
                        day = Convert.ToInt32(farsiDate.Substring(7, 2));
                    }
                    break;
            }
            return new[] { year, month, day };
        }
