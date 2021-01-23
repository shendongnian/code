    public event EventHandler PropertyChanged;
     public int SomeMember {
        get {
          return this.someMember;
        }
        set {
          if (this.someMember != value){
            someMember = value;
            if (PropertyChanged != null) { // if someone subscribed to the event
                    PropertyChanged(this, EventArgs.Empty); // raise the event
                }
          }
       }
...
    public void addChatter(ChattyClass chatter){
        myChatters.add(chatter);
        chatter.PropertyChanged += listner; // subscibe to the event
      }
    //this will be called on property changed
      private void listner(object sender, EventArgs e){
        Console.WriteLine("hey! hey! listen! a property of a chatter in my list has changed!");
      }
