     /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                AllStates.Add(new State { Index = 1 });
                AllStates.Add(new State { Index = 2 });
                AllStates.Add(new State { Index = 3 });
                AllStates.Add(new State { Index = 4 });
            }
    
            private ObservableCollection<State> allStates = new ObservableCollection<State>();
            public ObservableCollection<State> AllStates 
            {
                get { return allStates; }
                set { allStates = value; }
            }
    
            private int oneArrow;
            public int OneArrow
            {
                get { return oneArrow; }
                set { oneArrow = value; }
            }
            
        }
    
        public class State : INotifyPropertyChanged
        {
            private int index;
            public int Index
            {
                get { return index; }
                set { index = value; NotifyPropertyChanged("Index"); }
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void NotifyPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
            }
        }
