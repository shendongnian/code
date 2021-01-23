    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace AddressBookInC
    {
        class Addresses
        {
            private static int _incrementId = 0;
    
            public Addresses()
            {
                AddressID = _incrementId++;
            }
    
            public int AddressID { get; set; }
            public String FirstName { get; set; }
            public String LastName { get; set; }
            public String AddressEmail { get; set; }
            public String PhoneNumber { get; set; }
        }
    }
