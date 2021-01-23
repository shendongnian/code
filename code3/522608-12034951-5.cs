    public int SomeMember {
        get {
            return this.someMember;
        }
        set {
            if (this.someMember != value){
                someMember = value;
                if (PropertyChanged != null) { // If someone subscribed to the event
                    PropertyChanged(this, new PropertyChangedEventArgs("SomeMember")); // Raise the event
                }
            }
       }
       private void listner(object sender, PropertyChangedEventArgs e) {
           string propertyName = e.PropertyName;
           Console.WriteLine(String.Format("Hey! Hey! Listen! a {0} of a chatter in my list has changed!", propertyName));
       }
