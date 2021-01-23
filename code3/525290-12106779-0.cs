        public static Dictionary<int, string> getPostals()
        {
            Dictionary<int, string> oZipcodes = new Dictionary<int, string>();
            DBReservationDataContext oDBConnection = new DBReservationDataContext();
            var vAllCities = (from oCity in oDBConnection.tblCities
                              where (from oAccomodation in oDBConnection.tblAccomodations
                                     select oAccomodation.CityID).Contains(oCity.ID)
                              select oCity).Distinct();
            foreach (tblCity item in vAllCities)
            {
                oZipcodes.Add(item.ID, clsCities.getCityInfo(item.ID, "Zipcode") + ' ' + clsCities.getCityInfo(item.ID, "UpName"));
            }
            return oZipcodes;
        }
