     public partial class Window6 : Window
        {
            private RandomConnectionAdder adder;
            private ObservableCollection<Connection> Connections;
    
            public Window6()
            {
                InitializeComponent();
                Connections = new ObservableCollection<Connection>();
                adder = new RandomConnectionAdder(x => Dispatcher.BeginInvoke((Action) (() => AddConnection(x))));
                DataContext = Connections;
            }
    
            private void AddConnection(Connection connection)
            {
                Connections.Add(connection);
            }
        }
