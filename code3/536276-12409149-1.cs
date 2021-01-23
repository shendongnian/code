    public class AuthorInfo : FrameworkElement
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(AuthorInfo), new PropertyMetadata(default(string), PropertyChangedCallback));
        public static readonly DependencyProperty CollectionProperty =
            DependencyProperty.Register("Collection", typeof (IEnumerable), typeof (AuthorInfo), new PropertyMetadata(default(IEnumerable), PropertyChangedCallback));
        private static readonly DependencyPropertyKey ValuePropertyKey =
            DependencyProperty.RegisterReadOnly("Value", typeof (bool), typeof (AuthorInfo), new PropertyMetadata(default(bool)));
        public static readonly DependencyProperty ValueProperty = ValuePropertyKey.DependencyProperty;
        public bool BookMatches
        {
            get
            {
                return (bool) GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValuePropertyKey, value);
            }
        }
        public IEnumerable Collection
        {
            get
            {
                return (IEnumerable)GetValue(CollectionProperty);
            }
            set
            {
                SetValue(CollectionProperty, value);
            }
        }
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }
        protected void UpdateValue()
        {
            var books = Collection == null ? Enumerable.Empty<Book>() : Collection.Cast<Book>();
            BookMatches = !string.IsNullOrEmpty(Text) && books.Any(b => b.Name.StartsWith(Text));
        }
        private void CollectionSubscribe(INotifyCollectionChanged collection)
        {
            if (collection != null)
            {
                collection.CollectionChanged += CollectionOnCollectionChanged;
                foreach (var item in (IEnumerable)collection)
                {
                    CollectionItemSubscribe(item as INotifyPropertyChanged);
                }
            }
        }
        private void CollectionUnsubscribe(INotifyCollectionChanged collection)
        {
            if (collection != null)
            {
                collection.CollectionChanged -= CollectionOnCollectionChanged;
                foreach (var item in (IEnumerable)collection)
                {
                    CollectionItemUnsubscribe(item as INotifyPropertyChanged);
                }
            }
        }
        private void CollectionItemSubscribe(INotifyPropertyChanged item)
        {
            if (item != null)
            {
                item.PropertyChanged += ItemOnPropertyChanged;
            }
        }
        private void CollectionItemUnsubscribe(INotifyPropertyChanged item)
        {
            if (item != null)
            {
                item.PropertyChanged -= ItemOnPropertyChanged;
            }
        }
        private void CollectionOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.OldItems != null)
            {
                foreach (var item in args.OldItems)
                {
                    CollectionItemUnsubscribe(item as INotifyPropertyChanged);
                }
            }
            if (args.NewItems != null)
            {
                foreach (var item in args.NewItems)
                {
                    CollectionItemSubscribe(item as INotifyPropertyChanged);
                }
            }
            UpdateValue();
        }
        private void ItemOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            UpdateValue();
        }
        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var aggregator = (AuthorInfo)dependencyObject;
            if (args.Property == CollectionProperty)
            {
                aggregator.CollectionUnsubscribe(args.OldValue as INotifyCollectionChanged);
                aggregator.CollectionSubscribe(args.NewValue as INotifyCollectionChanged);
            }
            aggregator.UpdateValue();
        }
    }
