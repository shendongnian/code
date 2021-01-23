     public partial class DataGridConnectors : Window
        {
            public List<string> Items1 { get; set; }
    
            public List<string> Items2 { get; set; }
    
            public List<DataItemConnector> Connectors { get; set; }
    
            private ObservableCollection<DataItemConnector> _visibleConnectors;
            public ObservableCollection<DataItemConnector> VisibleConnectors
            {
                get { return _visibleConnectors ?? (_visibleConnectors = new ObservableCollection<DataItemConnector>()); }
            }
    
            public DataGridConnectors()
            {
                Connectors = new List<DataItemConnector>();
    
                InitializeComponent();
                Loaded += OnLoaded;
    
                Items1 = Enumerable.Range(0, 1000).Select(x => "Item1 - " + x.ToString()).ToList();
                Items2 = Enumerable.Range(0, 1000).Select(x => "Item2 - " + x.ToString()).ToList();
    
                DataContext = this;
            }
    
            private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
            {
                var scrollviewer1 = FindDescendent<ScrollViewer>(DG1).FirstOrDefault();
                var scrollviewer2 = FindDescendent<ScrollViewer>(DG2).FirstOrDefault();
    
                if (scrollviewer1 != null)
                    scrollviewer1.ScrollChanged += scrollviewer_ScrollChanged;
    
                if (scrollviewer2 != null)
                    scrollviewer2.ScrollChanged += scrollviewer_ScrollChanged;
            }
    
            private void scrollviewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
            {
                var visiblerows1 = GetVisibleContainers(Items1, DG1.ItemContainerGenerator);
                var visiblerows2 = GetVisibleContainers(Items2, DG2.ItemContainerGenerator);
    
                var visibleitems1 = visiblerows1.Select(x => x.DataContext);
                var visibleitems2 = visiblerows2.Select(x => x.DataContext);
    
                var visibleconnectors = Connectors.Where(x => visibleitems1.Contains(x.Start) &&
                                                              visibleitems2.Contains(x.End));
    
                VisibleConnectors.Where(x => !visibleconnectors.Contains(x))
                                 .ToList()
                                 .ForEach(x => VisibleConnectors.Remove(x));
    
                visibleconnectors.Where(x => !VisibleConnectors.Contains(x))
                                 .ToList()
                                 .ForEach(x => VisibleConnectors.Add(x));
    
                foreach(var connector in VisibleConnectors)
                {
                    var startrow = visiblerows1.FirstOrDefault(x => x.DataContext == connector.Start);
                    var endrow = visiblerows2.FirstOrDefault(x => x.DataContext == connector.End);
    
                    if (startrow != null)
                        connector.StartPoint = Point.Add(startrow.TransformToAncestor(Root).Transform(new Point(0, 0)), 
                                                         new Vector(startrow.ActualWidth + 5, (startrow.ActualHeight / 2)*-1));
    
                    if (endrow != null)
                        connector.EndPoint = Point.Add(endrow.TransformToAncestor(Root).Transform(new Point(0, 0)),
                                                       new Vector(-5,(endrow.ActualHeight / 2 ) * -1));
    
                }
    
            }
    
            private static List<FrameworkElement> GetVisibleContainers(IEnumerable<object> source, ItemContainerGenerator generator)
            {
                return source.Select(generator.ContainerFromItem).Where(x => x != null).OfType<FrameworkElement>().ToList();
            }
    
            public static List<T> FindDescendent<T>(DependencyObject element) where T : DependencyObject
            {
                var f = new List<T>();
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
                {
                    var child = VisualTreeHelper.GetChild(element, i);
    
                    if (child is T)
                        f.Add((T)child);
    
                    f.AddRange(FindDescendent<T>(child));
                }
                return f;
            }
    
            private void Sequential_Click(object sender, RoutedEventArgs e)
            {
                Connectors.Clear();
                Enumerable.Range(0, 1000).Select(x => new DataItemConnector() { Start = Items1[x], End = Items2[x] })
                                        .ToList()
                                        .ForEach(x => Connectors.Add(x));
    
                scrollviewer_ScrollChanged(null, null);
            }
    
            private void Random_Click(object sender, RoutedEventArgs e)
            {
                Connectors.Clear();
                var random = new Random();
    
                Enumerable.Range(500, random.Next(600, 1000))
                          .Select(x => new DataItemConnector()
                                        {
                                            Start = Items1[random.Next(0, 999)],
                                            End = Items2[random.Next(0, 999)]
                                        })
                          .ToList()
                          .ForEach(Connectors.Add);
                          
    
                scrollviewer_ScrollChanged(null, null);
            }
        }
