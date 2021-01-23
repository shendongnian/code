    [DataContract]
    public class Account
    {
        #region properties
    
        private int _accountId;
    
        [DataMember]
        public int AccountID
        {
           // get/set
        }
    
    
        private string _title;
        [DataMember]
    
        public string Title
        {
           // get/set
        }
    }
