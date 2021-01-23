public CollectionViewSource MyCollectionViewSource 
{
  get
  {
    return myCollectionViewSource;
  }
  set
  {
    myCollectionViewSource = value;
    // make sure to raise INotifyPropertyChanged here
  }
}
</pre>
