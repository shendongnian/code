    public class SelectableItem<T> : INotifyPropertyChanged
    {
      public event PropertyChangedEventHandler PropertyChanged;
      protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
      {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
      public SelectableItem(T val)
      {
        Value = val;
        _isSelected = false;
      }
 
      public T Value { get; private set; }
      private bool _isSelected;
      public bool IsSelected
      {
        get => _isSelected;
        set
        {
          if (_isSelected == value) return;
          _isSelected = value;
          OnPropertyChanged();
        }
      }
    }
