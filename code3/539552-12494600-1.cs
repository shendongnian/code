        public class GridItem
        {
          public string DocumentName { get; set; }
          public ICommand DeleteCommand { get; set; }
        }
        public class MyViewModel
        {
          public ObservableCollection<GridItem> GridData { get; set; }
        }
