    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
    var dictionary = new Dictionary<string, object>
                                 {
                                     {"Id", new Guid()}, 
                                     {"Name", "Phil"}, 
                                     {"Phone", "12345678"}
                                 };
    var customer = new Customer();
    foreach (var pair in dictionary)
    {
         var propertyInfo = typeof(Customer).GetProperty(pair.Key);
         propertyInfo.SetValue(customer, pair.Value, null);
    }
