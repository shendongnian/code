    public abstract class BusinessObjectViewModel : ViewModelBase
    {
        protected abstract BusinessObject BusinessObject { get; }
    
        protected BusinessObject Model { get { return this.BusinessObject; } }
    }
    
    public abstract class PersonViewModel : BusinessObjectViewModel
    {
        protected abstract Person Person { get; }
    
        protected new Person Model { get { return this.Person; } }
    
        protected override sealed BusinessObject BusinessObject
        {
            get { return this.Model; }
        }
    }
    
    public class CustomerViewModel : PersonViewModel
    {
        protected new Customer Model { get; set; }
    
        protected override sealed Person Person
        {
            get { return this.Model; }
        }
    }
    
    public class EmployeeViewModel : PersonViewModel
    {
        protected new Employee Model { get; set; }
    
        protected override sealed Person Person
        {
            get { return this.Model; }
        }
    }
