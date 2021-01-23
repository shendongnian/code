    public class BusinessObjectViewModel : ViewModelBase
    {
        protected BusinessObject Model { get; private set; }
    
        public BusinessObjectViewModel(BusinessObject model)
        {
            this.Model = model;
        }
    }
    
    public class PersonViewModel : BusinessObjectViewModel
    {
        protected new Person Model { get { return (Person)base.Model; } }
    
        public PersonViewModel(Person model)
            : base(model)
        {
        }
    }
    
    public class CustomerViewModel : PersonViewModel
    {
        protected new Customer Model { get { return (Customer)base.Model; } }
    
        public CustomerViewModel(Customer model)
            : base(model)
        {
        }
    }
    
    public class EmployeeViewModel : PersonViewModel
    {
        protected new Employee Model { get { return (Employee)base.Model; } }
    
        public EmployeeViewModel(Employee model)
            : base(model)
        {
        }
    }
