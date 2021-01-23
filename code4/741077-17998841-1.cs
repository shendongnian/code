            public class ViewModel:INotifyPropertyChanged
        {
            bool myChoice1;
            public bool MyChoice1
            {
                get { return myChoice1; }
                set { 
                    myChoice1 = value;
                    Notify("MyChoice1");
                }
            }
            bool myChoice2;
            public bool MyChoice2
            {
                get { return myChoice2; }
                set
                {
                    myChoice2 = value;
                    Notify("MyChoice2");
                }
            }
            bool myChoice3;
            public bool MyChoice3
            {
                get { return myChoice3; }
                set
                {
                    myChoice3 = value;
                    Notify("MyChoice3");
                }
            }
            public void Notify(string propName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
            
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
