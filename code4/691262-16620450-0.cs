        private string firstName, lastName;
        public string Name
        {
            get { return string.Concat(firstName, " ", lastName); }
            set
            {
                string name = value;
                if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException("Name"); }
                var nameParts = name.Trim().Split(' ');
                if (nameParts.Length != 2) { throw new ArgumentException("Invalid name value"); }
                firstName = nameParts[0];
                lastName = nameParts[1];
            }
        }
