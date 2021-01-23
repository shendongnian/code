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
                get
                {
                    return this._tabPages;
                }
            }
            // Events
            private void OnPropretyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (sender == null) // If list got set
                {
                    // Remove existing tabpages
                    this._tabPages.Clear();
                    // Loop through all items inside the ObservableList object and add them to the Tabpage
                    foreach (TreeNodeItem _treeNodeItem in this._treeNodeItems)
                    {
                        TabPage tabPage = new TabPage() { Text = _treeNodeItem.Value, Tag = _treeNodeItems };
                        this._tabPages.Add(tabPage);
                    }
                }
                else if (sender is object[]) // If only one (or multiple) objects have been changed
                {
                    // Get OldItems and NewItems
                    object[] changedItems = (object[])sender;
                    // Remove OldItems
                    if (changedItems[0] != null)
                    {
                        foreach (dynamic oldItems in (IList)changedItems[0])
                        {
                            foreach (TabPage tab in this._tabPages)
                            {
                                if (tab.Text == oldItems.Value)
                                {
                                    this._tabPages.Remove(tab);
                                    break;
                                }
                            }
                        }
                    }
                    // Add OldItems
                    if (changedItems[1] != null)
                    {
                        foreach (dynamic newItems in (IList)changedItems[1])
                        {
                            TabPage tabPage = new TabPage() { Text = newItems.Value, Tag = newItems };
                            this._tabPages.Add(tabPage);
                        }
                    }
                }
            }
        }
