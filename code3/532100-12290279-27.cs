    public class View : UserControl
    {
        public View()
        {
            InitializeComponents();
    
            this.DataContext = new ViewModel();
        }
    }
