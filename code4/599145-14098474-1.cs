    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using App82.Common;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    namespace App82
    {
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
                var items = new ObservableCollection<BindableBase>();
                var item1 = new BasicItem { Title = "Item 1", Gist = "This item has some content that is not fully shown..." };
                var item2 = new ExpandedItem { Title = "Item 2", Gist = "This item has some content that is not fully shown..." };
                var item3 = new ExpandedItem { Title = "Item 3", Gist = "This item has some content that is not fully shown..." };
                var item4 = new ExpandedItem { Title = "Item 4", Gist = "This item has some content that is not fully shown..." };
                var item5 = new BasicItem { Title = "Item 5", Gist = "This item has some content that is not fully shown..." };
                var itemGroup1 = new CollapsibleItem(items, new[] { item2, item3, item4 });
                items.Add(item1);
                items.Add(itemGroup1);
                items.Add(item5);
                this.ListView.ItemsSource = items;
            }
            private void OnItemClick(object sender, ItemClickEventArgs e)
            {
                var collapsibleItem = e.ClickedItem as CollapsibleItem;
                if (collapsibleItem != null)
                    collapsibleItem.ToggleCollapse();
            }
        }
        public class CollapsibleListItemTemplateSelector : DataTemplateSelector
        {
            public DataTemplate BasicItemTemplate { get; set; }
            public DataTemplate CollapsibleItemTemplate { get; set; }
            public DataTemplate ExpandedItemTemplate { get; set; }
            protected override Windows.UI.Xaml.DataTemplate SelectTemplateCore(object item, Windows.UI.Xaml.DependencyObject container)
            {
                if (item is ExpandedItem)
                    return ExpandedItemTemplate;
                if (item is BasicItem)
                    return BasicItemTemplate;
                //if (item is CollapsibleItem)
                    return CollapsibleItemTemplate;
            }
        }
        public class BasicItem : BindableBase
        {
            #region Title
            private string _title;
            public string Title
            {
                get { return _title; }
                set { this.SetProperty(ref _title, value); }
            }
            #endregion
            #region Gist
            private string _gist;
            public string Gist
            {
                get { return _gist; }
                set { this.SetProperty(ref _gist, value); }
            }
            #endregion
        }
        public class ExpandedItem : BasicItem
        {
        
        }
        public class CollapsibleItem : BindableBase
        {
            private readonly IList _hostCollection;
            #region IsExpanded
            private bool _isExpanded;
            public bool IsExpanded
            {
                get { return _isExpanded; }
                set
                {
                    if (this.SetProperty(ref _isExpanded, value))
                    {
                        if (_isExpanded)
                            Expand();
                        else
                            Collapse();
                    }
                }
            }
            #endregion
        
            #region ChildItems
            private ObservableCollection<BasicItem> _childItems;
            public ObservableCollection<BasicItem> ChildItems
            {
                get { return _childItems; }
                set { this.SetProperty(ref _childItems, value); }
            }
            #endregion
            public CollapsibleItem(
                IList hostCollection,
                IEnumerable<BasicItem> childItems)
            {
                _hostCollection = hostCollection;
                _childItems = new ObservableCollection<BasicItem>(childItems);
            }
            public void ToggleCollapse()
            {
                IsExpanded = !IsExpanded;
            }
            private void Expand()
            {
                int i = _hostCollection.IndexOf(this) + 1;
                foreach (var childItem in ChildItems)
                {
                    _hostCollection.Insert(i++, childItem);
                }
            }
            private void Collapse()
            {
                int i = _hostCollection.IndexOf(this) + 1;
                for (int index = 0; index < ChildItems.Count; index++)
                {
                    _hostCollection.RemoveAt(i);
                }
            }
        }
    }
