    public static Dictionary<int, string> getPostals()
    {
        Dictionary<int, string> oPostals = new Dictionary<int, string>();
    
        using (DBReservationDataContext oReservation = new DBReservationDataContext())
        {
            var oAllPostals = (from oAccomodation in oReservation.tblAccomodations
                                orderby oAccomodation.Name ascending
                                select oAccomodation);
    
            foreach (tblAccomodation item in oAllPostals)
            {
                oPostals.Add((item.Postal + item.City).GetHashCode(), item.Postal + " " + item.City);
            }
        }
        return oPostals;
    }
