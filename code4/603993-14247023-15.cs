    public partial class View: IView 
    {
        public View()
        {
            // access you VM by the strategy of your framework or choice - this example is when you store your VM in View's DataContext
            (DataContext as ViewModel).View = this as IView;
        } 
        public void AddTextBoxToGrid() 
        {  
            // implement here your custom view logic using standard code behind; 
        }
    }
