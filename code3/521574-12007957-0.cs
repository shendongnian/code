        interface IContact
        {
            string Status { get; }
            string Name { get; }
        }
        class FBContact : IContact
        {
            public string Status
            {
                get
                {
                    // Implement the status getter   
                }
            }
            public string Name
            {
                get
                {
                    // Implement the contact name getter   
                }
            }
        } 
