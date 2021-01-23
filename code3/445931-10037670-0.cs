    public class Customer
    {
        public int CustomerID { get; set; }
        // or implement it via enum like below for policy type
        public bool Existing { get; set; }
        public bool AgeIn { get; set; }
        public bool New{ get; set; }
        // no 'virtual' means it's 'required', with virtual could be 'null'
        public Policy Policy { get; set; }
    }
    public enum PolicyBits
    {
        None = 0x00,
        ExistingOriginalMediCare = 0x01,
        // ...
        AgeInOriginalMediCare = 0x100,
        // ...
    }
    public class Policy
    {
        public int PolicyID { get; set; }
        public int PolicyTypeValue { get; set; }
		[NotMapped]
		public PolicyBits PolicyType
		{
		    get { return (PolicyBits)PolicyTypeValue; }
		    set { PolicyTypeValue = (int)value; }
		}
    }
