    using System.Collections.ObjectModel;
    using GalaSoft.MvvmLight;
    
    namespace Test_DataGridSelectedIndexItem
    {
        public class MainViewModel : ViewModelBase
        {
            private ItemViewMode selected;
            private int selectedIndex;
    
            public MainViewModel()
            {
                this.Items = new ObservableCollection<ItemViewMode>()
                             {
                                 new ItemViewMode("Item1"),
                                 new ItemViewMode("Item2"),
                                 new ItemViewMode("Item3"),
                             };
            }
    
            public ObservableCollection<ItemViewMode> Items { get; private set; }
    
            public ItemViewMode Selected
            {
                get
                {
                    return this.selected;
                }
                set
                {
                    this.selected = value;
                    this.RaisePropertyChanged(() => this.Selected);
                }
            }
    
            public int SelectedIndex
            {
                get
                {
                    return this.selectedIndex;
                }
                set
                {
                    this.selectedIndex = value;
                    this.RaisePropertyChanged(() => this.SelectedIndex);
                }
            }
        }
    }
