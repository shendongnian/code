    public ICollectionView CollectionView
        {
            get
            {
                collectionViewSource.Source = dataColl;
                if (SortDescriptions != null)
                {
                    foreach (SortDescription sd in SortDescriptions)
                    {
                        collectionViewSource.View.SortDescriptions.Add(sd);
                    }
                }
                collectionViewSource.View.Refresh();
                return collectionViewSource.View;
            }
        }
