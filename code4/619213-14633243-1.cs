    public class CustomerViewModel
        {
           public long CustomerID { get; set; }
           public ICollection<CustomerContact> CustomerContacts { get; set; }
        }
