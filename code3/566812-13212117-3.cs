    public class Client
    {
        public Client(string IPAddress, string SubnetMask, string UniqueID, string LeaseExpires, string ClientType, Reservation ClientReservation)
        {
            this.IPAddress = IPAddress;
            this.SubnetMask = SubnetMask;
            this.UniqueID = UniqueID;
            this.LeaseExpires = LeaseExpires;
            this.ClientType = ClientType;
            this.ClientReservation = ClientReservation;
        }
        public string IPAddress { get; set; }
        public string SubnetMask { get; set; }
        public string UniqueID { get; set; }
        public string LeaseExpires { get; set; }
        public string ClientType { get; set; }
        public Reservation ClientReservation { get; set; }
    }
