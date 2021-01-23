    public class Customer 
    {
        public int CustomerID { get; set; }        
        public string EncryptedField { get; private set; }
    
        [NotMapped]
        public string Field
        {
            get { return MyEncryptionFunction.Decrypt(EncryptedField); }
            set { EncryptedField = MyEncryptionFunction.Encrypt(value); }
        } 
    }
