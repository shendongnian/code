    public class ViewModel
    {
        public Action CloseAction { get; set; }
        private void CloseCommandFunction()
        {
            CloseAction();
        }
    }
