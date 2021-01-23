    public class DynamicLineChartPlotter : Microsoft.Research.DynamicDataDisplay.ChartPlotter
    {
        public static DependencyProperty ItemsSourceProperty =
                DependencyProperty.Register("ItemsSource",
                                            typeof(IEnumerable),
                                            typeof(DynamicLineChartPlotter),
                                            new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnItemsSourceChanged)));
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(true)]
        public IEnumerable ItemsSource
        {
            get
            {
                return (IEnumerable)GetValue(ItemsSourceProperty);
            }
            set
            {
                if (value == null)
                    ClearValue(ItemsSourceProperty);
                else
                    SetValue(ItemsSourceProperty, value);
            }
        }
        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DynamicLineChartPlotter control = (DynamicLineChartPlotter)d;
            IEnumerable oldValue = (IEnumerable)e.OldValue;
            IEnumerable newValue = (IEnumerable)e.NewValue;
            if (e.OldValue != null)
            {
                control.ClearItems();
            }
            if (e.NewValue != null)
            {
                control.BindItems((IEnumerable)e.NewValue);
            }
        }
        private void ClearItems()
        {
            Children.Clear();
        }
        private void BindItems(IEnumerable items)
        {
            foreach (var item in items)
            {
                var template = GetTemplate(item);
                if (template == null) continue;
                FrameworkElement obj = template.LoadContent() as FrameworkElement;
                obj.DataContext = item;
                Children.Add((IPlotterElement)obj);
            }
        }
        private DataTemplate GetTemplate(object item)
        {
            foreach (var key in this.Resources.Keys)
            {
                if (((DataTemplateKey)key).DataType as Type == item.GetType())
                {
                    return (DataTemplate)this.Resources[key];
                }
            }
            return null;
        }
    }
