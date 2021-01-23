    public interface IMyData : INotifyPropertyChanged
    {
      Properties...
    }
    
    public interface IMyModel
    {
       IList<IMyData> Items { get; set; }
    
       void Serialize(string filePath);
    
       void Deserialize(string filePath);
    }
    
    public interface IMyViewModel : INotifyPropertyChanged
    {
       IMyModel Model { get; set; }
    
       ObservableCollection<IMyData> Items { get; set; }
       ICommand Save { get; }
       ICommand Load { get; }
       ICommand Add { get; }
       ICommand Remove { get; }
    }
