    ICollectionView ItemsSource;
    ...
    public bool IsNotEmpty(){     
        return !ItemsSource.IsEmpty;
    }
