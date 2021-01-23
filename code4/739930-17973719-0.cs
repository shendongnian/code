    public class Bookings : IEnumerable<tblBooking>
    {
        public List<tblBooking> BookedIn { get; set; }
        public List<tblBooking> BookedOut { get; set; }
        public IEnumerator<tblBooking> GetEnumerator()
        {
            return Union().GetEnumerator();
        }
        private IEnumerable<tblBooking> Union()
        {
            return BookedIn.Union(BookedOut);
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Union().GetEnumerator();
        }
    }
