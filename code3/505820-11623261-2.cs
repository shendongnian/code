    public class PersonModel : IValidatableObject 
    {
        private System.Type _typeOfAddress;
        private object _address;
    
        [Required]
        public int PersonId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
    
        public System.Type typeOfAddress
        {
            get { return (AddressOne ?? AddressTwo ?? AddressThree).GetType(); }
        }
    
        public AdressOneModel AddressOne {get;set;}
        public AdressTwoModel AddressTwo {get;set;}
        public AdressThreeModel AddressThree {get;set;}
    }
