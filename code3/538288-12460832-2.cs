    public class CustomerViewModel
    {
        // Keeping these generic to reduce code here, but it
        // should include PropertyChange notification
        public AddressModel Address { get; set; }
    
        public CustomerViewModel()
        {
            Address = new AddressModel();
            Address.AddValidationDelegate(ValidateAddress);
        }
    
        // Validation Delegate to validate Adderess
        private string ValidateAddress(object sender, string propertyName)
        {
            // Do your ViewModel-specific validation here.
            // sender is your AddressModel and propertyName 
            // is the property on the address getting validated
    
            // For example:
            if (propertyName == "Street1" && string.IsNullOrEmpty(Address.Street1))
                return "Street1 cannot be empty";
    
            return null;
        }
    }
