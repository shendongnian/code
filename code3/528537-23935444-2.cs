        public class TabControlBind
        {
            public TabControlBind(TabControl tabControl)
            {
                // Create a new TabPageCollection and bind it to our tabcontrol
                this._tabPages = new TabControl.TabPageCollection(tabControl);
            }
            // Fields
            private ObservableList<TreeNodeItem> _treeNodeItems;
            private TabControl.TabPageCollection _tabPages;
            // Properties
            public ObservableList<TreeNodeItem> TreeNodeItems
            {
                get { return _treeNodeItems; }
                set
                {
                    if (_treeNodeItems != value)
                    {
                        _treeNodeItems = value;
                        _treeNodeItems.OnPropertyChanged += OnPropretyChanged;
                        OnPropretyChanged(null, null);
                    }
                }
            }
            public TabControl.TabPageCollection TabPages
            {
                get { return _tabPages; }
            }
            // Events
            public event EventHandler ClickHandler;
            private void OnPropretyChanged(object sender, PropertyChangedEventArgs e)
            {
                // Remove existing tabpages
                this._tabPages.Clear();
                // Loop through all items inside the ObservableList object and add them to the Tabpage
                foreach (TreeNodeItem _treeNodeItem in this._treeNodeItems)
                {
                    TabPage tabPage = new TabPage() { Text = _treeNodeItem.Value, Tag = _treeNodeItems };
                    if (ClickHandler != null)
                        tabPage.Click += ClickHandler;
                    this._tabPages.Add(tabPage);
                }
            }
        }
