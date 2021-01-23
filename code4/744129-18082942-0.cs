    public class CustomerContactDetails
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
    ...
    var contactDetails = customersList.Select(customer => new CustomerContactDetails { Address = customer.Address, Email = customer.Email, Telephone = customer.Telephone });
