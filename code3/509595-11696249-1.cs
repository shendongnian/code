    public partial class MainWindow : Window
    {
        public ReadOnlyObservableCollection<ProductType> ProductTypes
        {
            get { return (ReadOnlyObservableCollection<ProductType>)GetValue(ProductTypesProperty); }
            set { SetValue(ProductTypesProperty, value); }
        }
    
        // Using a DependencyProperty as the backing store for ProductTypes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductTypesProperty =
            DependencyProperty.Register("ProductTypes", typeof(ReadOnlyObservableCollection<ProductType>), typeof(MainWindow), new UIPropertyMetadata(null));
    
        public MainWindow()
        {
            this.InitializeComponent();
    
            this.ProductTypes = new ReadOnlyObservableCollection<ProductType>(
                new ObservableCollection<ProductType>()
                {
                    new ProductType() 
                    { 
                        Description = "Type A",
                        AvailableInstallerObjects = new ReadOnlyObservableCollection<InstallerObject>(
                            new ObservableCollection<InstallerObject>()
                            {
                                new InstallerObject() { FileName = "A" },
                                new InstallerObject() { FileName = "B" },
                                new InstallerObject() { FileName = "C" },
                            })
                    },
    
                    new ProductType() 
                    { 
                        Description = "Type B",
                        AvailableInstallerObjects = new ReadOnlyObservableCollection<InstallerObject>(
                            new ObservableCollection<InstallerObject>()
                            {
                                new InstallerObject() { FileName = "A" },
                                new InstallerObject() { FileName = "D" },
                            })
                    }
                });
    
            this.DataContext = this;
        }
    }
