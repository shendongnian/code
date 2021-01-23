    public class ViewModel
    {
        public Model employees { get; set; }
        public myCommand NextCommand { get; set; }
       
        public ViewModel()
        {
            employees = new Model()
            {
                empdetails = new Employee()
                {
                    fname = "John",
                    lname = "Doe",
                    gender = gender.Male
                }
            };
            NextCommand = new myCommand(myNextCommandExecute, myCanNextCommandExecute);
        }
        private void myNextCommandExecute(object parameter)
        {
            employees.empdetails.fname = "Ally";
            employees.empdetails.lname = "Smith";
            employees.empdetails.gender = gender.Female;
        }
        private bool myCanNextCommandExecute(object parameter)
        {
            return true;
        }
    }
