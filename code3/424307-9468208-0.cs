    public class MyClass<ABC>
        {
            private void DataGridCollectionViewSource_CommittingNewItem(
                  object sender, DataGridCommittingNewItemEventArgs e)
            {
                Type t = e.CollectionView.SourceCollection.GetType();
            if (t == typeof(List<ABC>))
            {
                List<ABC> source = e.CollectionView.SourceCollection as List<ABC>;
                source.Add(e.Item as ABC);
            }
        }
    }
