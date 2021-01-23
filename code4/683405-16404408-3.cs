    public class ParentViewModel // Derive from some viewModel base that implements INPC
    {
        public ParentViewModel()
        {
             childViewModel = new ChildViewModel();
             childViewModel.SomeEvent += someEventHandler;
             // Don't forget to un-subscribe from the event at some point...
        }
        private void SomeEventHandler(object sender, MyArgs args)
        {
            // Update your calculations from here...
        }
    }
