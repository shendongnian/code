        private string firstName;
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string FirstName
        {
            get
            {
                //Put here any condition for serializing
                return string.IsNullOrWhiteSpace(firstName) ? null : firstName;
            }
            set
            {
                firstName = value;
            }
        }
