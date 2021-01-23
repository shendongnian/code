    public interface IUserView
    {
        string FirstName { get; }
        string LastName { get; }
    }
    public class UserForm : IUserView, Form
    {
        //initialise all your Form controls here
        public string FirstName
        {
            get { return this.txtFirstName.Text; }
        }
        public string LastName
        {
            get { return this.txtLastName.Text; }
        }
    }
    public class UserController
    {
        private readonly IUserView view;
        public UserController(IUserView view)
        {
            this.view = view;
        }
        public void DoSomething()
        {
            Console.WriteLine("{0} {1}", view.FirstName, view.LastName);
        }
    }
    Bind<IUserView>().To<UserForm>();
    Bind<UserController>().ToSelf();
    
    //will inject a UserForm automatically, in the MVP pattern the view would inject itself though    
    UserController uc = kernel.Get<UserController>(); 
    uc.DoSomething();
