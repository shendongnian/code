    public Scope
    {
        //...
        public void AddClient(string IPAddress, string SubnetMask, string UniqueID, string LeaseExpires, string ClientType, Reservation ClientReservation){
            Clients.Add(new Client(IPAddress, SubnetMask, UniqueID, LeaseExpires, ClientType, ClientReservation));
        }
    }
