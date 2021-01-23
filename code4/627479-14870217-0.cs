    public class EmployeeView : UserControl
    {
        public EmployeeView(IEmployeeViewModel vm)
        {
             this.DataContext = vm; //// better to set the ViewModel in the Loaded method
        }
    }
