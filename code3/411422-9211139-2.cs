     public interface IApplicationService
        {
            List<User> Users{get;set;}
        }
        
        public class ApplicationService : IApplicationService
        {
            public List<User> Handlers
            {
                get { return (App.Current as App).Users; }
                set { (App.Current as App).Users = value; }
            }
        }
        
        public partial class MainWindow : UserControl
        {
            readonly IApplicationService _applicationService
            public MainWindow(IApplicationService applicationService)
            {
                _applicationService=applicationService;
            }
        }
