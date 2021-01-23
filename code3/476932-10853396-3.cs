    public class WatchViewModel
    {
        public ObservableCollection<WatchRow> WatchRows { get; set; }
        public void GetWatchRows()
        {
            WatchRows= new ObservableCollection<WatchRow>();
        }
        public void AddWatchRow(int value, string color)
        {
            var item=new WatchRow(value, color);
            WatchRows.Add(item);
        }
    }
