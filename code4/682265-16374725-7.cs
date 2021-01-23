     public class MotionTitleItemViewModel : INotifyPropertyChanged
     {
    ObservableCollection<MotionTitleItem> _remoteItemsList = new ObservableCollection<MotionTitleItem>();
    public ObservableCollection<MotionTitleItem> RemoteItemsList
    {
      get { return _remoteItemsList; }
      set { _remoteItemsList = value; }
    }
    ObservableCollection<MotionTitleItem> _libraryItemsList = new ObservableCollection<MotionTitleItem>();
    public ObservableCollection<MotionTitleItem> LibraryItemsList
    {
      get { return _libraryItemsList; }
      set { _libraryItemsList = value; }
    }
    public MotionTitleItemViewModel()
    {
      MotionTitleItem motion;
      for (int i = 0; i < 10; i++)
      {
        motion = new MotionTitleItem();
        motion.Name = "Name " + i.ToString();
        this.LibraryItemsList.Add(motion);
        this.RemoteItemsList.Add(motion);
      }     
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
      try
      {
        PropertyChangedEventHandler eventHandler = this.PropertyChanged;
        if (null == eventHandler)
          return;
        else
        {
          var e = new PropertyChangedEventArgs(propertyName);
          eventHandler(this, e);
        }
      }
      catch (Exception)
      {
        throw;
      }
    } }
