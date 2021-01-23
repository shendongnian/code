    public class ViewModel : BindableBase
    {
        private object _selectedItem;
    
        public object SelectedItem
        {
            get { return this._selectedItem; }
            set { this.SetProperty(ref this._selectedItem, value); }
        }
    }
