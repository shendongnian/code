    public partial class MainWindow:window
    {
        public class ApplicationService : IApplicationService
        {
              public List<User> Users
              {
                 get { return App.Current.Users;}
              }
    }
