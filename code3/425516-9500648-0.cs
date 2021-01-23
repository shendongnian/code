    public class MyViewModel
    {
        public ObservableCollection<PersonViewModel> PersonList
        {
            get { return somerandomclasss.thepeoplelist; }
        }
        ...
    }
    <ListBox ItemsSource="{Binding PersonList}" ... />
