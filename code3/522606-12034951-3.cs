    public int SomeMember {
        get {
          return this.someMember;
        }
        set {
          if (this.someMember != value){
            someMember = value;
            if (PropertyChanged != null) { // if someone subscribed to the event
                    PropertyChanged(this, new PropertyChangedEventArgs("SomeMember")); // raise the event
                }
          }
       }
    private void listner(object sender, PropertyChangedEventArgs e) {
                string propertyName = e.PropertyName;
                Console.WriteLine(String.Format("hey! hey! listen! a {0} of a chatter in my list has changed!", propertyName));
            }
