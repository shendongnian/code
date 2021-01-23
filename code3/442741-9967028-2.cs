    [Export(typeof (SharingScreen2ViewModel))]
        public class SharingScreen2ViewModel : Screen
        {
            [ImportingConstructor]
            public SharingScreen2ViewModel(ISharedViewModel sharedViewModel)
            {
                DisplayName = "Shared Data Screen 2";
    
                SharedViewModel = sharedViewModel;
            }
    
            public ISharedViewModel SharedViewModel { get; set; }
    
            public void ChangeSharedData()
            {
                SharedViewModel.FirstName = "New First Name";
                SharedViewModel.LastName = "New Last Name:";
                SharedViewModel.Address = "New Address";
            }
        }
