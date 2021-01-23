    public string[] GetSeatInfoStrings(DisplayOptions choice)
        {
            List<string> lstSeatInfoStrings = new List<string>();
            
            for (int i = 0; i < totalNumberOfSeats; i++)
            {
                string seatInfo = GetSeatInfoAt(i);
                if (seatInfo.Reserved)
                {
                    lstSeatInfoStrings.Add(seatInfo);
                }
                
            }
            if (lstSeatInfoStrings.Count == 0)
            {
                return null;
            }
            return lstSeatInfoStrings.ToArray();
        }
