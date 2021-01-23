    public partial class Window1 : Window, INotifyPropertyChanged
    {
        public Window1()
        {
            InitializeComponent();
            this.ImagePoints = new PointCollection
                (new [] { new Point(1, 2), new Point(34, 12), new Point(12, 99) });
            
            //Important - maybe you missed this?
            this.DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        PointCollection imagePoints;
        public PointCollection ImagePoints
        {
            get
            {
                return this.imagePoints;
            }
            set
            {
                if (this.imagePoints != value)
                {
                    this.imagePoints = value;
                    if (this.PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ImagePoints"));
                    }
                }
            }
        }
        private void btnSetNew(object sender, RoutedEventArgs e)
        {
            this.ImagePoints = new PointCollection(
                new[] { new Point(23, 2), new Point(12, 556), new Point(4, 89) });
        }
    }
