    public static Dictionary<int, Tuple<string, string>> getPostals()
    {
        Dictionary<int, string> oPostals = new Dictionary<int, string>();
    
        using (DBReservationDataContext oReservation = new DBReservationDataContext())
        {
            var oAllPostals = (from oAccomodation in oReservation.tblAccomodations
                                orderby oAccomodation.Name ascending
                                select oAccomodation);
    
            foreach (tblAccomodation item in oAllPostals)
            {
                oPostals.Add((item.Postal + item.City).GetHashCode(), new Tuple<string, string>(item.Postal, item.City));
            }
        }
        return oPostals;
    }
