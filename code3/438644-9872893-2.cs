    public class ViewModel<T> : DataTemplateSelector, INotifyPropertyChanged
    {
        #region Properties
        //this is just a placeholder for the collection, no changes will be made to this collection
        private ObservableCollection<T> leftCollectionRef;
        //local collection
        private ObservableCollection<T> leftCollection;
        public ObservableCollection<T> LeftCollection
        {
            get
            {
                return leftCollection;
            }
            set
            {
                if (value != leftCollectionRef)
                {
                    //remove subscription to previous collection
                    if (leftCollectionRef != null)
                        leftCollectionRef.CollectionChanged -= new NotifyCollectionChangedEventHandler(Ref_CollectionChanged);
                    leftCollectionRef = value;
                    leftCollection.Clear();
                    foreach (var item in leftCollectionRef)
                    {
                        if (rightCollection.IndexOf(item) == -1)
                            leftCollection.Add(item);
                    }
                    NotifyPropertyChanged("LeftCollection");
                    //subscribe to chnages in new collection
                    leftCollectionRef.CollectionChanged += new NotifyCollectionChangedEventHandler(Ref_CollectionChanged);
                }
            }
        }
        //this is just a placeholder for the collection, no changes will be made to this collection
        private ObservableCollection<T> rightCollectionRef;
        private ObservableCollection<T> rightCollection;
        public ObservableCollection<T> RightCollection
        {
            get
            {
                return rightCollection;
            }
            set
            {
                if (value != rightCollectionRef)
                {
                    //remove subscription to previous collection
                    if (rightCollectionRef != null)
                        rightCollectionRef.CollectionChanged -= new NotifyCollectionChangedEventHandler(Ref_CollectionChanged);
                    rightCollectionRef = value;
                    rightCollection.Clear();
                    foreach (var item in rightCollectionRef)
                    {
                        if (leftCollection.IndexOf(item) == -1)
                            rightCollection.Add(item);
                    }
                    NotifyPropertyChanged("RightCollection");
                    rightCollectionRef.CollectionChanged += new NotifyCollectionChangedEventHandler(Ref_CollectionChanged);
                }
            }
        }
        private string bindingMember;
        public string BindingMember
        {
            get
            {
                return bindingMember;
            }
            set
            {
                var mem = typeof(T).GetProperty(value);
                if (mem == null)
                    throw new ArgumentException("No Member " + value + " found in " + this.GetType().FullName);
                if (bindingMember != value)
                {
                    bindingMember = value;
                    NotifyPropertyChanged("BindingMember");
                }
            }
        }
        #endregion
        #region Constructors
        public ViewModel()
            : base()
        {
            // internal collection, this will get items copied over from reference source collection
            leftCollection = new ObservableCollection<T>();
            // internal collection, this will get items copied over from reference target collection
            rightCollection = new ObservableCollection<T>();
            bindingMember = "";
        }
        #endregion
        #region Movements
        public void MoveItems(ListBox list, bool LeftToRight)
        {
            var source = leftCollection;
            var target = rightCollection;
            if (!LeftToRight)
            {
                target = leftCollection;
                source = rightCollection;
            }
            if (list.SelectedItems.Count > 0)
            {
                // List for items to be removed.
                var hitList = new List<T>();
                // Move items
                foreach (T item in list.SelectedItems)
                {
                    if (item != null)
                    {
                        // Tag item for removal
                        hitList.Add(item);
                        // Check if item is in target list
                        if (target.IndexOf(item) == -1)
                        {
                            target.Add(item);
                        }
                    }
                }
                // Remove items
                foreach (var hitItem in hitList)
                {
                    source.Remove(hitItem);
                }
            }
        }
        public void MoveAllItems(bool LeftToRight)
        {
            if (LeftToRight)
            {
                rightCollection.Clear();
                foreach (var item in leftCollection)
                {
                    RightCollection.Add(item);
                }
                leftCollection.Clear();
            }
            else
            {
                leftCollection.Clear();
                foreach (var item in rightCollection)
                {
                    leftCollection.Add(item);
                }
                rightCollection.Clear();
            }
        }
        #endregion
        #region collection-monitor
        private void Ref_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                var target = leftCollection;
                if (sender == leftCollectionRef)
                    target = leftCollection;
                else
                    target = rightCollection;
                foreach (T item in e.NewItems)
                {
                    target.Add(item);
                }
            }
            //try remove from both collections, since the item may have moved to right or left collections
            if (e.OldItems != null && e.OldItems.Count > 0)
            {
                foreach (T item in e.OldItems)
                {
                    leftCollection.Remove(item);
                }
                foreach (T item in e.OldItems)
                {
                    rightCollection.Remove(item);
                }
            }
        }
        #endregion
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
        #region templateselector
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            string dataTemplate =
                @"<DataTemplate  
                xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">  
                    <TextBlock Margin=""2"" TextWrapping=""Wrap"" Text=""{Binding Path=" + this.bindingMember + @", Mode=OneWay}""/>  
                </DataTemplate>";
            StringReader stringReader = new StringReader(dataTemplate);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            return XamlReader.Load(xmlReader) as DataTemplate;
        }
        #endregion
    }
