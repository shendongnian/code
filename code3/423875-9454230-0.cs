    /// <summary>
    /// A computer manufacturer. They resupply us.
    /// </summary>
    public class Vendor
    {
        string id;
        public string VendorId
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public Vendor(string vendorId)
        {
            id = vendorId;
        }
        public virtual void AskForRessuply()
        {
            Console.WriteLine("Please ressuply me, vendor "+id+".");
        }
    }
    /// <summary>
    /// A customer. We send them their purchased goods.
    /// </summary>
    public class Customer
    {
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public Customer(string customerName)
        {
            name = customerName;
        }
        public virtual void SendOrder()
        {
            Console.WriteLine("Dear "+name+": We are sending your goods.");
        }
    }
    /// <summary>
    /// The auxiliary class that redefines Customer.
    /// </summary>
    internal class CustomerAux : Customer
    {
        // <--- It has a link to the Shop object that contains it.
        internal Shop shopPart;        
        internal CustomerAux(string customerName) : base (customerName)
        {
        }
        // We declare the implicit casting operator for returning 
        // shopPart when a Shop object is expected.
        static public implicit operator Shop(CustomerAux c)
        {
            return c.shopPart;
        }
    }
    /// <summary>
    /// We consider a shop like a Vendor and a Customer, 
    /// for we both ask them to resupply us,
    /// or they purchase our goods.
    /// </summary>
    public class Shop : Vendor        // <-- It inheirs only from Vendor...
    {
        CustomerAux customerPart;    // ...but has a CustomerAux object inside.
        // Shops have an address in addition to the vendor id 
        // and the customer name inherited from Vendor and Customer.
        string address;                
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        // Here we are 'redirecting' property Name to the customerPart object.
        public string Name        
        {
            get
            {
                return customerPart.Name;
            }
            set
            {
                customerPart.Name = value;
            }
        }
        // The Shop constructor. 
        public Shop(string vendorId, string customerName, string shopAddress) : 
                                                                  base (vendorId)
        {
            // We create and bind the CustomerAux object to this one.
            customerPart = new CustomerAux(customerName);    
            customerPart.shopPart = this;
            address = shopAddress;
        }
        // Here we are redirecting Customer.SendOrder to the customerPart object.
        public virtual void SendOrder()
        {
            customerPart.SendOrder();
        }
        // We redefine the implicit casting operator for returning 
        // customerPart when a Customer object is expected.
        static public implicit operator Customer(Shop s)
        {
            return s.customerPart;
        }
    }
    // An example of use of the Vendor, Customer and Shop classes.
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Vendor ibm = new Vendor("32FK-IBM");
            Vendor hp = new Vendor("1138-HP");
            Customer mrSimpson = new Customer("Mr. Simpson");
            Customer mrGates = new Customer("Mr. Gates");
            Shop joys = 
              new Shop("1979-JCS", "Joy's Computer Shop", "123, Fake St.");
            Vendor[] vendors = {ibm, hp, joys};
            foreach(Vendor ven in vendors)
                ven.AskForRessuply();
            
            Customer[] customers = {mrSimpson, mrGates, joys};
            foreach(Customer cus in customers)
                cus.SendOrder();
            Console.ReadLine();            
        }
    }
