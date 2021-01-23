    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        ViewModel ViewModel { get { return this.DataContext as ViewModel; } }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.ViewModel.MovePrevious();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.ViewModel.MoveNext();
        }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel() { SelectedThing = ThingList.First(); }
        List<int> m_ThingList = Enumerable.Range(1, 50).ToList();
        public List<int> ThingList { get { return m_ThingList; } set { SetProperty(ref m_ThingList, value); } }
        int m_SelectedThing = default(int);
        public int SelectedThing { get { return m_SelectedThing; } set { SetProperty(ref m_SelectedThing, value); } }
        internal void MovePrevious()
        {
            var _CurrentIndex = ThingList.IndexOf(this.SelectedThing);
            try { SelectedThing = ThingList[--_CurrentIndex]; }
            catch { SelectedThing = ThingList.First(); }
        }
        internal void MoveNext()
        {
            var _CurrentIndex = ThingList.IndexOf(this.SelectedThing);
            try { SelectedThing = ThingList[++_CurrentIndex]; }
            catch { SelectedThing = ThingList.Last(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void SetProperty<T>(ref T storage, T value, [System.Runtime.CompilerServices.CallerMemberName] String propertyName = null)
        {
            if (!object.Equals(storage, value))
            {
                storage = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
