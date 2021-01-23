    class newText
    {
        public String newtext
        {
            get 
            { 
                return this.newtext; //Get newtext again, which gets it again, and again, etc
            }
            set 
            { 
                this.newtext = value; //Set newtext, which calls set again, and again...
            }
        }
    }
