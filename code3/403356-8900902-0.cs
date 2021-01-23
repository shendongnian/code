    public class ModalWindow : Window
    {
        private MainWindow _parent;
        public ModalWindow(MainWindow parent)
        {
            _parent = parent;
            Owner = parent;
        }
    
        void CallParent()
        {
            _parent.Call();
        }
    }
