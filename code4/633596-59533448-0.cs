        ListCollectionView lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(MyDatagrid.ItemsSource);
                    
                    if (lcv.IsAddingNew)
                        lcv.CommitNew();
                    if (lcv.IsEditingItem)
                        lcv.CommitEdit();
