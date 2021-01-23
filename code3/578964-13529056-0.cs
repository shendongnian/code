    public partial class Customer : EntityObject
    {
        public Address BillingAddress
        {
             get 
             {
                 return this.Address;
             }
             set 
             {
                  this.Address = value;
             }
        }
    }
