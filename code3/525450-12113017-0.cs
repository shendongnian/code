    public class RequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Prov { get; set; }
        public string Request { get; set; }
        public bool UsageConditions { get; set; }
        public RequestModel(DrOkUser user )
        {
            if (user == null) return;
            var type = user.GetType().Name;         //Client o Supplier
            Email = user.Email;
            if (type == "Client")
            {
                FirstName = ((Client)user).FirstName;
                LastName = ((Client)user).LastName;
                Phone = ((Client)user).Phone;
                Prov = ((Client)user).Prov;
            }
            if (type == "Supplier")
            {
                FirstName = ((Supplier)user).FirstName;
                LastName = ((Supplier)user).LastName;
                Phone = ((Supplier)user).PrimaryPhone;
                Prov = ((Supplier)user).BusinessProv;
            }
        }
    }
