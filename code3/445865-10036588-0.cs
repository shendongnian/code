    class KeyEnumWrapper {
            public System.Windows.Forms.Keys key { get; set; }
    
            public KeyEnumWrapper(System.Windows.Forms.Keys key) {
                this.key = key;
            }
    
            public string ToString() {
                return "{" + key.ToString().ToUpper() + "}";
            }
        }
