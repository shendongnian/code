      public class NodeViewModel : ViewModelBase
      {
        private ViewModelLocator locator = new ViewModelLocator();
        public RelayCommand NodeCommand
        {
            get
            {
                return locator.Main.DefaultCommand;
            }
        }
    }
