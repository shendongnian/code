    internal class ViewModel
    {
        public ViewModel()
        {
            this.DeleteCommand = new RelayCommand(() => this.Delete());
        }
        public void Delete()
        {
            this.MyList.Remove(this.SelectedItem);
        }
    } 
