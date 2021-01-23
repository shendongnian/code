    public class DeskClerk {
        private ShowRoom { get; set; }
        public DeskClerk(ShowRoom showRoom) {
            ShowRoom = showRoom;
        }
        public Customer AddCustomer(Customer customer) {
            //do stuff with customer object
            ShowRoom.Add(customer);
            return cutomer;
        }
    }
