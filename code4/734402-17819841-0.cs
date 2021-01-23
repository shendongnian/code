        class Child {
            public Child() { }            
 
            // Define event
            public event EventHandler DidSomethingNaughty;
            // Proeprty used to trigger event
            public bool IsNaughty {
                get { return this.isNaughty; }
                set {
                    this.isNaughty = value;
                    if (this.IsNaughty) {
                        if (this.DidSomethingNaughty != null) {
                            this.DidSomethingNaughty(this, new EventArgs());
                        }
                    }
                }
            }
            // Private data member for property
            private bool isNaughty = false;
        }
