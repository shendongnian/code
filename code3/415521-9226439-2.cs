        dg.ItemsSource = ((DataSet)data).Table[0].DefaultView;
        dg.Columns.CollectionChanged
           += new NotifyCollectionChangedEventHandler(
                  Columns_CollectionChanged);
        void Columns_CollectionChanged(
             object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems.Count > 0)
            {
                foreach(DataGridColumn col in e.NewItems)
                {
                    if (col is DataGridTextColumn)
                    {
                        ((DataGridTextColumn) col).ElementStyle
                             = dg.Resources["WrappedTextBlockStyle"] as Style;
                    }
                }
            }
        }
