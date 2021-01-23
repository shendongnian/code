    public event EventHandler PropertyChanged;
     public int SomeMember {
        get {
          return this.someMember;
        }
        set {
          if (this.someMember != value){
            someMember = value;
            //raise event/fire handlers. But how?
            if (PropertyChanged != null) { // if someone subscribed to the event
                    PropertyChanged(this, EventArgs.Empty); // raise the event
                }
          }
       }
...
    public void addChatter(ChattyClass chatter){
        myChatters.add(chatter);
        //start listning to property changed events
        chatter.PropertyChanged += listner; // subscibe to the event
      }
    //this will be called on property changed
      private void listner(object sender, EventArgs e){
        //I want this to be called when the PropertyChangedEvent is called
        Console.WriteLine("hey! hey! listen! a property of a chatter in my list has changed!");
      }
