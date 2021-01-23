    public partial class View : IView 
    {
        public View()
        {
            DataContext.ViewModel.View = this as IView;
        } 
        public void AddTextBoxToGrid() 
        {  
            // implement here your custom view logic using standard code behind; 
        }
    }
