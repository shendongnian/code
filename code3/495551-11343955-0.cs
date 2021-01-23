    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Data;
    
    namespace SO11343251
    {
        public partial class MainWindow : Window
        {
            private readonly ICollection<ViewLookupItem> items;
            private readonly ICollectionView itemsView;
    
            public MainWindow()
            {
                InitializeComponent();
    
                this.items = new List<ViewLookupItem>();
    
                this.items.Add(new ViewLookupItem("Amenities", "No Group"));
                this.items.Add(new ViewLookupItem("Indoor", "Area"));
                this.items.Add(new ViewLookupItem("Outdoor", "Area"));
    
                this.itemsView = new ListCollectionView((IList)this.items);
                this.itemsView.GroupDescriptions.Add(new PropertyGroupDescription("Group"));
    
                this.DataContext = this;
            }
    
            public ICollection<ViewLookupItem> Items
            {
                get { return this.items; }
            }
    
            public ICollectionView ItemsView
            {
                get { return this.itemsView; }
            }
        }
    
        public class ViewLookupItem
        {
            private readonly string name;
            private readonly string group;
    
            public ViewLookupItem(string name, string group)
            {
                this.name = name;
                this.group = group;
            }
    
            public string Name
            {
                get { return this.name; }
            }
    
            public string Group
            {
                get { return this.group; }
            }
        }
    }
