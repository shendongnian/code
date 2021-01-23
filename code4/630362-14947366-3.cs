    using System.ComponentModel;
    public class Wrapper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int member;
        public int Member
        {
            get { return this.member; }
            set 
            {
                this.member = value;
                this.OnPropertyChanged("Member");
            }
        }
        protected void OnPropertyChanged(string name)
        {
          PropertyChangedEventHandler handler = PropertyChanged;
          if (handler != null)
          {
              handler(this, new PropertyChangedEventArgs(name));
          }
        }
    }
    public class ContainerClass
    {
        private Wrapper data;
        public Wrapper Property
        {
            get { return data; }
            set { data = value; }
        }
        public void Foo()
        {
            data.PropertyChanged += data_PropertyChanged;
            Property.Member = 42;
        }
        private void data_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Member")
            {
                DoStuff();
            }
        }
    }
