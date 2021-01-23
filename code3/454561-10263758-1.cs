    [DataContract(Name="Student")]
    public class Student
    {
        [DataMember(Name = "StudentID")]
        public string StudentID { get; set; }
        [DataMember(Name = "FirstName")]
        public string FirstName { get; set; }
        [DataMember(Name = "LastName")]
        public string LastName { get; set; }
        // local non public cache
        private byte[] _password;
        [DataMember(Name = "Password")]
        public byte[] Password {
            get { return _password; }
            set {
                this.Salt = GenerateSalt();
                this._password = Hash(value, this.Salt);
            }
        };
        [DataMember(Name = "Salt")]
        public byte[] Salt;
    
        // ...
