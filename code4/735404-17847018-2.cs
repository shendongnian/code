    class PlayerName {
        public string Prefix { get; set; }
        public string Name { get; set; }
        public string Suffix { get; set; }
        public string PlayerNameTotal {
            get {
                return String.Join(
                    " ",
                    new[] { this.Prefix, this.Name, this.Suffix }
                        .Where(s => !String.IsNullOrEmpty(s))
                );
            }
        }
    }
