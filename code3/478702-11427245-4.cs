    public sealed class AvalonDockRegionAdapter:
            RegionAdapterBase<DockingManager>
        {
            #region Constructor
    
            public AvalonDockRegionAdapter(IRegionBehaviorFactory factory)
                : base(factory)
            {
            }
    
            #endregion  //Constructor
    
    
            #region Overrides
    
            protected override IRegion CreateRegion()
            {
                return new AllActiveRegion();
            }
    
            protected override void Adapt(IRegion region, DockingManager regionTarget)
            {
                region.Views.CollectionChanged += delegate(
                    Object sender, NotifyCollectionChangedEventArgs e)
                    {
                        this.OnViewsCollectionChanged(sender, e, region, regionTarget);
                    };
            }
    
            #endregion  //Overrides
    
            #region Event Handlers
    
            /// <summary>
            /// Handles the NotifyCollectionChangedEventArgs event.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The event.</param>
            /// <param name="region">The region.</param>
            /// <param name="regionTarget">The region target.</param>
            void OnViewsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e, IRegion region, DockingManager regionTarget)
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement item in e.NewItems)
                    {
                        UIElement view = item as UIElement;
                        
                        if (view != null)
                        {
                            //Create a new layout document to be included in the LayoutDocuemntPane (defined in xaml)
                            LayoutDocument newLayoutDocument = new LayoutDocument();
                            //Set the content of the LayoutDocument
                            newLayoutDocument.Content = item;
    
                            ViewModelBase_2 viewModel = (ViewModelBase_2)item.DataContext;
    
                            if (viewModel != null)
                            {
                                //All my viewmodels have a property DisplayName
                                newLayoutDocument.Title = viewModel.DisplayName;
                            }
    
                            //Store all LayoutDocuments alraedy pertaining to the LayoutDocumentPane (defined in xaml)
                            List<LayoutDocument> oldLayoutDocuments = new List<LayoutDocument>();
                            foreach (LayoutDocumentPane oldLayoutDocumentPane in regionTarget.Layout.RootPanel.Children)
                            {
                                foreach (LayoutDocument child in oldLayoutDocumentPane.Children)
                                {
                                    oldLayoutDocuments.Insert(0, child);
                                }
                            }
    
                            //Create a new LayoutDocumentPane and inserts your new LayoutDocument
                            LayoutDocumentPane newLayoutDocumentPane = new LayoutDocumentPane();
                            newLayoutDocumentPane.InsertChildAt(0, newLayoutDocument);
                            
                            //Append to the new LayoutDocumentPane the old LayoutDocuments
                            foreach (LayoutDocument doc in oldLayoutDocuments)
                            {
                                newLayoutDocumentPane.InsertChildAt(0, doc);
                            }
    
                            //Register the new LayoutDocumentPane with the ChildrenCollectionChanged event to manage
                            //LayoutDocuments closure
                            newLayoutDocumentPane.ChildrenCollectionChanged += delegate(
                                Object documentPaneSender, EventArgs args)
                                {
                                    this.OnChildrenCollectionChanged(documentPaneSender, args, region);
                                };
    
                            //Traverse the visual tree of the xaml and replace the LayoutDocumentPane in xaml
                            //with your new LayoutDocumentPane
                            regionTarget.Layout.RootPanel.ReplaceChildAt(0, newLayoutDocumentPane);
                            
                            newLayoutDocument.IsActive = true;
                        }
                    }
                }
            }
    
            /// <summary>
            /// Handles the EventArgs event raised when the Children Collection of the LayoutDocumentPane is changed.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The event.</param>
            void OnChildrenCollectionChanged(object sender, EventArgs e, IRegion region)
            { 
                //Iterate through the collection of documents hosted by the document pane
                foreach (LayoutDocument document in (sender as LayoutDocumentPane).Children)
                {
                    //Remove invisible documents from the region
                    if (!document.IsVisible)
                    {
                        region.Remove(document);
                    }
                }
            }
    
            #endregion  //Event handlers 
