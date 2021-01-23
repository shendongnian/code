    public class DynamicLineChartPlotter : Microsoft.Research.DynamicDataDisplay.ChartPlotter {
        public static DependencyProperty ItemsSourceProperty =
                DependencyProperty.Register("ItemsSource",
                                            typeof(IEnumerable),
                                            typeof(DynamicLineChartPlotter),
                                            new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnItemsSourceChanged)));
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(true)]
        public IEnumerable ItemsSource {
            get {
                return (IEnumerable)GetValue(ItemsSourceProperty);
            }
            set {
                if (value == null)
                    ClearValue(ItemsSourceProperty);
                else
                    SetValue(ItemsSourceProperty, value);
            }
        }
        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            DynamicLineChartPlotter control = (DynamicLineChartPlotter)d;
            IEnumerable oldValue = (IEnumerable)e.OldValue;
            IEnumerable newValue = (IEnumerable)e.NewValue;
            if (e.NewValue == null)
                control.ClearItemsSource();
            else
                control.SetItemsSource(newValue);
        }
        private List<IPlotterElement> _elementsInItemsSource = new List<IPlotterElement>();
        private IEnumerable _itemsSource = null;
        public void ClearItemsSource() {
            if (_itemsSource != null && _itemsSource is INotifyCollectionChanged)
                (_itemsSource as INotifyCollectionChanged).CollectionChanged -= ItemsSourceCollectionChanged;
            //remove the elements that were added from the items source (create a copy since RemoveItemSourceChild changes the enumeration)
            List<IPlotterElement> removes = new List<IPlotterElement>(_elementsInItemsSource);
            foreach (IPlotterElement elem in removes)
                RemoveItemSourceChild(elem);
            _elementsInItemsSource.Clear();
        }
        private void SetItemsSource(IEnumerable list) {
            ClearItemsSource();
            foreach (object o in list) {
                if (o is IPlotterElement)
                    AddItemSourceChild(o as IPlotterElement);
            }
            _itemsSource = list;
            if (_itemsSource is INotifyCollectionChanged)
                (_itemsSource as INotifyCollectionChanged).CollectionChanged += ItemsSourceCollectionChanged;
        }
        private void RemoveItemSourceChild(IPlotterElement elem) {
            this.Children.Remove(elem);
            //it's not in the plotter anymore
            _elementsInItemsSource.Remove(elem);
        }
        private void AddItemSourceChild(IPlotterElement elem) {
            Children.Add(elem);
            //it's in the plotter not
            _elementsInItemsSource.Add(elem);
        }
        private void ItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            if (e.OldItems != null) {
                foreach (object o in e.OldItems) {
                    if (o is IPlotterElement)
                        RemoveItemSourceChild(o as IPlotterElement);
                }
            }
            if (e.NewItems != null) {
                foreach (object o in e.NewItems) {
                    if (o is IPlotterElement)
                        AddItemSourceChild(o as IPlotterElement);
                }
            }
        }
    }
