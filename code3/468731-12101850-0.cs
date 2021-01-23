    [DataContract(Namespace = DataContractNamespaces.ValueTypes)]
    public struct EmailAddress : IEquatable<EmailAddress>
    {
        private const char At = '@';
        public EmailAddress(string value) : this()
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            this.Value = value;
        }
        public bool IsWellFormed
        {
            get
            {
                return Regex.IsMatch(this.Value, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            }
        }
        public string Domain
        {
            get
            {
                return this.Value.Split(At)[1];
            }
        }
        [DataMember(Name = "Value")]
        private string Value { get; set; }
        public static bool operator ==(EmailAddress left, EmailAddress right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(EmailAddress left, EmailAddress right)
        {
            return !left.Equals(right);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return this.Equals(new EmailAddress(obj.ToString()));
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
        public override string ToString()
        {
            return this.Value;
        }
        public bool Equals(EmailAddress other)
        {
            return other != null && this.Value.Equals(other.ToString(), StringComparison.OrdinalIgnoreCase);
        }
    }
