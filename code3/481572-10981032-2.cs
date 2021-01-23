    public class Contact
    { 
       private List<Address> _addresses = new List<Address>();       
       public IEnumerable<Address> Addresses { get { return _addresses; }
    }
    public class ContactConverter : CustomCreationConverter<Contact>
    {
        public override Contact Create(Type objectType)
        {
            return new Contact();
        }
 
        public override object ReadJson(JsonReader reader, Type objectType, object 
            existingValue, JsonSerializer serializer)
        {
            var mappedObj = new Contact();
            
            // Parse JSON data here
            // ...
           
            return mappedObj;
        }
    }
