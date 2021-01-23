           public partial class MainWindow : Window, INotifyPropertyChanged
            {
                private Model model;
        
                public Model Model
                {
                    get { return model; }
                    set
                    {
                        model = value;
                        if (PropertyChanged != null)
                            PropertyChanged(this, new PropertyChangedEventArgs("Model"));
                    }
                }
    public MainWindow()
        {
            InitializeComponent();
            Model = new Model();
            MyGrid.ItemsSource = Model.Content;
        }
          event PropertyChangedEventHandler PropertyChanged;
