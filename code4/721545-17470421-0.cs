    public class Harvest_Project
        {
            public string Name { get; set; }
            public int clientId { get; set; }
        }
    
        public class Harvest_Client
        {
            private Harvest_Project MyInstance;
    
            private int myid;
    
            public int MyId
            {
                get
                {
                    return myid;
                }
                private set
                {
                    MyId = value;
                }
            }
            public Harvest_Client(Harvest_Project cls)
            {
                MyInstance = cls;
                MyId = cls.clientId;//since class reference present no 
                                    //need for the property.
                                    //its just here to show if in your
                                    //project you really just need ID
                                    //in this example its redundant
            }
    
        }
