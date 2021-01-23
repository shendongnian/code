     [Export(typeof (SharingScreen1ViewModel))]
        public class SharingScreen1ViewModel : Screen
        {
            [ImportingConstructor]
            public SharingScreen1ViewModel(ISharedViewModel sharedViewModel)
            {
                DisplayName = "Shared Data Screen 1";
    
                SharedViewModel = sharedViewModel;
            }
    
            public ISharedViewModel SharedViewModel { get; set; }
    
            protected override void OnInitialize()
            {
                base.OnInitialize();
    
                SharedViewModel.FirstName = "Jimmy";
                SharedViewModel.LastName = "Hugh";
                SharedViewModel.Address = "555 South St.";
            }
        }
