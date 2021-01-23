    public class IndexedListBox : System.Windows.Controls.ListBox
    {
        public static int GetIndex(DependencyObject obj)
        {
            return (int)obj.GetValue(IndexProperty);
        }
        public static void SetIndex(DependencyObject obj, int value)
        {
            obj.SetValue(IndexProperty, value);
        }
        /// <summary>
        /// Keeps track of the index of a ListBoxItem
        /// </summary>
        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.RegisterAttached("Index", typeof(int), typeof(IndexedListBox), new UIPropertyMetadata(0));
        public static bool GetIsLast(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsLastProperty);
        }
        public static void SetIsLast(DependencyObject obj, bool value)
        {
            obj.SetValue(IsLastProperty, value);
        }
        /// <summary>
        /// Informs if a ListBoxItem is the last in the collection.
        /// </summary>
        public static readonly DependencyProperty IsLastProperty =
            DependencyProperty.RegisterAttached("IsLast", typeof(bool), typeof(IndexedListBox), new UIPropertyMetadata(false));
        protected override void OnItemsSourceChanged(System.Collections.IEnumerable oldValue, System.Collections.IEnumerable newValue)
        {
            // We capture the ItemsSourceChanged to check if the new one is modifiable, so we can react to its changes.
            var oldSource = oldValue as INotifyCollectionChanged;
            if(oldSource != null)
                oldSource.CollectionChanged -= ItemsSource_CollectionChanged;
            var newSource = newValue as INotifyCollectionChanged;
            if (newSource != null)
                newSource.CollectionChanged += ItemsSource_CollectionChanged;
            base.OnItemsSourceChanged(oldValue, newValue);
        }
        void ItemsSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.ReindexItems();
        }
        protected override void PrepareContainerForItemOverride(System.Windows.DependencyObject element, object item)
        {
            // We set the index and other related properties when generating a ItemContainer
            var index = this.Items.IndexOf(item); 
            SetIsLast(element, index == this.Items.Count - 1);
            SetIndex(element, index);
            base.PrepareContainerForItemOverride(element, item);
        }
        private void ReindexItems()
        {
            // If the collection is modified, it may be necessary to reindex all ListBoxItems.
            foreach (var item in this.Items)
            {
                var itemContainer = this.ItemContainerGenerator.ContainerFromItem(item);
                if (itemContainer == null) continue;
                int index = this.Items.IndexOf(item);
                SetIsLast(itemContainer, index == this.Items.Count - 1);
                SetIndex(itemContainer, index);
            }
        }
    }
