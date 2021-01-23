        class Mother {
            public Mother() {
                this.subscribeToChildEvent();
            }
            // Properties
            public Child Child1 {
                get { return this.child1; }
                set { this.child1 = value; }
            }
            public Child Child2 {
                get { return this.child1; }
                set { this.child2 = value; }
            }
            
            public Child Child3 {
                get { return this.child3; }
                set { this.child3 = value; }
            }
            
            public Child Child4 {
                get { return this.child4; }
                set { this.child4 = value; }
            }
            // Private data members for the properties
            private Child child1 = new Child();
            private Child child2 = new Child();
            private Child child3 = new Child();
            private Child child4 = new Child();
            // This uses reflection to get the properties find those of type child
            // and subscribe to the DidSomethingNaughty event for each
            private void subscribeToChildEvent() {
                System.Reflection.PropertyInfo[] properties = 
                    typeof(Mother).GetProperties();
                foreach (System.Reflection.PropertyInfo pi in properties) {
                    if (pi.ToString().StartsWith("Child")) {
                        Child child = pi.GetValue(this, null) as Child;
                        child.DidSomethingNaughty +=
                            new EventHandler(child_DidSomethingNaughty);
                    }
                }
            }
            
            private void  child_DidSomethingNaughty(object sender, EventArgs e){
                Child child = (Child)sender;
                if (child.IsNaughty) {
                    this.discipline(child);
                }
            }
            
            private void discipline(Child child) {                
                MessageBox.Show("Someone was naughty");
                // reset the flag so the next time the childe is
                //naughty the event will raise
                child.IsNaughty = false;
            }
        }
