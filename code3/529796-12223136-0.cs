    class FacebookMessage
    {
        public int SenderID { get; set; }
        public int AddresseeID { get; set; }
        public string SenderName { get; set; }
        public string AddresseeName { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public FacebookMessage()
        {
            SenderID = 0;
            AddresseeID = 0;
            SenderName = "";
            AddresseeName = "";
            Message = "";
        }
    }
