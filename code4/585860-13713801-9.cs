    public class PinList
    {
        public ObservableCollection<Pin> list;
        public static ObservableCollection<Pin> MainPinList = new ObservableCollection<Pin>();
        public void Refresh()
        {
             // Here you update the comments list of each of your Pins - The comment
             //     list is an ObservableCollection so your display will automatically
             //     update itself. If you have to change an existing comment due to
             //     an edit or something that will automatically update as well since
             //     we've implemented INotifyPropertyChanged
        }
    }
