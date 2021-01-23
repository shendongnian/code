    public event EventHandler PropertyChanged;
        public int SomeMember {
            get {
                return this.someMember;
            }
            set {
                if (this.someMember != value) {
                    someMember = value;
                    if (PropertyChanged != null) { // If someone subscribed to the event
                        PropertyChanged(this, EventArgs.Empty); // Raise the event
                    }
                }
            }
...
    public void addChatter(ChattyClass chatter) {
        myChatters.add(chatter);
        chatter.PropertyChanged += listner; // Subscribe to the event
    }
    // This will be called on property changed
    private void listner(object sender, EventArgs e){
        Console.WriteLine("Hey! Hey! Listen! A property of a chatter in my list has changed!");
    }
