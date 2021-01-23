        private  Ansprechpartner partner;
        public virtual Ansprechpartner Partner
        {
            get
            {    
                // legal assignment thanks to **public static implicit operator Ansprechpartner(string s)**
                return partner ?? String.Empty;            
            }
            set
            {
                partner = value;
            }
        }
