    public class MyViewModel
    {
        IList<Reservation> Reservations { get; set; }
        public MyViewModel() {
            this.Reservations = new List<Reservation>();
        }
    }
