            private CxmlCollectionSource _cxml;
        void pViewer_Loaded(object sender, RoutedEventArgs e)
        {
            _cxml = new CxmlCollectionSource(new Uri("http://myurl.com/test.cxml",
                                                 UriKind.Absolute));
            _cxml.StateChanged += _cxml_StateChanged;
        }
        void _cxml_StateChanged(object sender,
                               CxmlCollectionStateChangedEventArgs e)
        {
            if(e.NewState == CxmlCollectionState.Loaded)
            {
                pViewer.PivotProperties =
                           _cxml.ItemProperties.ToList();
                pViewer.ItemTemplates =
                           _cxml.ItemTemplates;
                pViewer.ItemsSource =
                           _cxml.Items;
            }
        }
