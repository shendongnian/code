        // May be set by a code or by an user.
        public string Property
        {
            set 
            { 
                internalSetProperty(value);
                PropertyChanged(this, EventArgs.Empty); 
            }
        }
        internal internalSetProperty(string value)
        {
            // Code of set.
        }
        
