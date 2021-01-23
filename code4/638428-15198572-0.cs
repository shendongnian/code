    public partial class Map : UserControl
    {
        public Map()
        {
            InitializeComponent();
            this.Loaded += Map_Loaded;
        }
        void Map_Loaded(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MyViewModel).LoadingItemsCompleted += OnLoadingItemsCompleted;
        }
        private void OnLoadingItemsCompleted(object sender, EventArgs eventArgs)
        {
            // Don't care about thats
            ObservableCollection<DependencyObject> children = Microsoft.Phone.Maps.Toolkit.MapExtensions.GetChildren(map);
            MapItemsControl itemsControl = children.FirstOrDefault(x => x.GetType() == typeof(MapItemsControl)) as MapItemsControl;
            // Here !
            foreach (GeolocalizableModel item in (this.DataContext as MyViewModel).Items)
            {
                Pushpin pushpin = new Pushpin();
                switch (item.PushpinTemplate)
                {
                    case Server.PushpinTemplate.First:
                        pushpin.Template = this.Resources["firstPushpinTemplate"] as ControlTemplate;
                        break;
                    case Server.PushpinTemplate.Second:
                        pushpin.Template = this.Resources["secondPushpinTemplate"] as ControlTemplate;
                        break;
                    case Server.PushpinTemplate.Third:
                        pushpin.Template = this.Resources["thirdPushpinTemplate"] as ControlTemplate;
                        break;
                    default:
                        if (PushpinTemplate != null) pushpin.Template = PushpinTemplate;
                        break;
                }
                pushpin.Content = item.PushpinContent;
                pushpin.GeoCoordinate = item.Location;
                itemsControl.Items.Add(pushpin);
            }
        }
        public ControlTemplate PushpinTemplate
        {
            get { return (ControlTemplate)GetValue(PushpinTemplateProperty); }
            set { SetValue(PushpinTemplateProperty, value); }
        }
        // Using a DependencyProperty as the backing store for PushpinTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PushpinTemplateProperty =
            DependencyProperty.Register("PushpinTemplate", typeof(ControlTemplate), typeof(Map), new PropertyMetadata(null));
    }
