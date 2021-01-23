    class ViewModel
    {
        public Action CloseAction { get; set; }
        private void Stuff()
        {
           // Do Stuff
           CloseAction(); // closes the window
        }
    }
