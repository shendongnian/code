    public class VirtualizingNotifyTextBlock : TextBlock
    {
        private INotifyPropertyChanged _dataItem;
        private string _propertyName;
    
        public VirtualizingNotifyTextBlock()
            : base()
        {
            this.TargetUpdated += NotifyTextBlock_TargetUpdated;
        }
        public static readonly RoutedEvent PropertyChangedEvent = EventManager.RegisterRoutedEvent("PropertyChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(VirtualizingNotifyTextBlock));
        public static readonly DependencyProperty NotifyDurationProperty = DependencyProperty.Register("NotifyDuration", typeof(int), typeof(VirtualizingNotifyTextBlock), new PropertyMetadata(300));
        public static readonly DependencyProperty NotifyRepeatProperty = DependencyProperty.Register("NotifyRepeat", typeof(int), typeof(VirtualizingNotifyTextBlock), new PropertyMetadata(3));
        public static readonly DependencyProperty NotifyColorProperty = DependencyProperty.Register("NotifyColor", typeof(Color), typeof(VirtualizingNotifyTextBlock), new PropertyMetadata(Colors.Red));
        public Color NotifyColor
        {
            get { return (Color)GetValue(NotifyColorProperty); }
            set { SetValue(NotifyColorProperty, value); }
        }
        public int NotifyDuration
        {
            get { return (int)GetValue(NotifyDurationProperty); }
            set { SetValue(NotifyDurationProperty, value); }
        }
        public int NotifyRepeat
        {
            get { return (int)GetValue(NotifyRepeatProperty); }
            set { SetValue(NotifyRepeatProperty, value); }
        }
        public INotifyPropertyChanged DataItem
        {
            get { return _dataItem; }
            set
            {
                if (_dataItem != null)
                {
                    Background = new SolidColorBrush(Colors.Transparent);
                    _dataItem.PropertyChanged -= DataItem_PropertyChanged;
                }
                _dataItem = value;
                if (_dataItem != null)
                {
                    _dataItem.PropertyChanged += DataItem_PropertyChanged;
                }
            }
        }
        
        private void NotifyTextBlock_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            var binding = this.GetBindingExpression(VirtualizingNotifyTextBlock.TextProperty);
            if (binding != null)
            {
                _propertyName = binding.ResolvedSourcePropertyName;
                DataItem = binding.DataItem as INotifyPropertyChanged;
            }
        }
        private void DataItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == _propertyName)
            {
               var animation = new ColorAnimation(NotifyColor, new Duration(TimeSpan.FromMilliseconds(NotifyDuration)));
               animation.RepeatBehavior = new RepeatBehavior(NotifyRepeat);
               animation.AutoReverse = true;
               Background = new SolidColorBrush(Colors.Transparent);
               Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);
            }
        }
        
    }
