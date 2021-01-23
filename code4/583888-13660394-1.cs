     namespace Test
    {
      public  class Delivery
        {
            private string name;
            private string address;
            private DateTime arrivalTime;
    
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
    
            public string Address
            {
                get { return address; }
                set { address = value; }
            }
    
            public DateTime ArrivlaTime
            {
                get { return arrivalTime; }
                set { arrivalTime = value; }
            }
    
            public string ToString()
            {
                { return name + address + arrivalTime.ToString(); }
            }
        }
    }
