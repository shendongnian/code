    public partial View : IView 
    {
        public View()
        {
            DataContext.ViewModel.View = this as IView;
        } 
        public void AddTextBoxToGrid() { implement here using standard code behind; }
    }
