        public class ViewModel : //implement notify property changed and ICommand
        {
            public RelayCommand ButtonClickCommand
            {
                 get new RelayCommand(EventHandlerToBeCalled);
            }
            
            public string SelectedItemBinding
            {
                 get;
                 set
                 {
                      //notify property changed.
                 }
            }
            //method called when button is clicked.
            private void EventHandlerToBeCalled()
            {
                  //here set the SelectedItemBinding to a column.
            }
        }
