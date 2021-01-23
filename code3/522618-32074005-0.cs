    public class ChattyClass  : INotifyPropertyChanged 
    {
      private int someMember, otherMember;
      public int SomeMember
      {
          get
          {
              return this.someMember;
          }
          set
          {
              if (this.someMember != value)
              {
                  someMember = value;
                  OnPropertyChanged("Some Member");
              }
          }
      }
      public int OtherMember
      {
          get
          {
              return this.otherMember;
          }
          set
          {
              if (this.otherMember != value)
              {
                  otherMember = value;
                  OnPropertyChanged("Other Member");
              }
          }
      }
      protected virtual void OnPropertyChanged(string propertyName)
      {
          PropertyChangedEventHandler handler = PropertyChanged;
          if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
      }
      public event PropertyChangedEventHandler PropertyChanged;
    
    }
    public class NosyClass
    {
        private List<ChattyClass> myChatters = new List<ChattyClass>();
        public void AddChatter(ChattyClass chatter)
        {
            myChatters.Add(chatter);
            chatter.PropertyChanged+=chatter_PropertyChanged;
        }
        private void chatter_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("A property has changed: " + e.PropertyName);
        }
    }
