    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace AddressBookInC
    {
        public class Addresses: List<Address> { }
        public class Address
        {
            public int AddressID { get; set; }
            public String FirstName { get; set; }
            public String LastName { get; set; }
            public String AddressEmail { get; set; }
            public String PhoneNumber { get; set; }
        }
    }
