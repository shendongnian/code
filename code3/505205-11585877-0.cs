        public List<string> EmailAddress { get; set; }
        public string EmaiAddressString {
            get {
                string rValue = string.Empty;
                EmailAddress.ForEach(x => rValue += (x + "\n" ));
                return rValue;
            }
            set {
                var newValue = value.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList<string>();
                EmailAddress = newValue;
            }
        }
    }
