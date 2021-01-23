    [DataContract] 
    public class ADPerson 
    { 
        Guid objectGuid; 
        Guid managerObjectGuid; 
        string username; 
        string displayname; 
     
        [DataMember] 
        public string Username  
        {  
            get { return this.username; } 
            set { this.username = value; } 
        } 
        [DataMember] 
        public string DisplayName 
        {  
            get { return this.displayName; } 
            set { this.displayName = value; } 
        } 
        public ADPerson Manager 
        {  
            get { return new ADPerson(this.managerObjectGuid); } 
            set { this.managerObjectGuid = value.objectGuid; } 
        } 
        [DataMember] 
        public string ManagerUsername
        {  
            get { return this.Manager.Username; } 
        } 
        [DataMember] 
        public string ManagerName
        {  
            get { return this.Manager.DisplayName; } 
        } 
    } 
