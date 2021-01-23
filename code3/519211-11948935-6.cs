    namespace Whatever {
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lbxFirst.DataContext = new MyModel();
        }
    }
    public class MyModel
    {
        public IEnumerable<ProfileUser> ProfileUsers
        {
            get
            {
                var tmp = new[]
                {
                    new ProfileUser{ User_ID = "001", Login = "Adelle", Address = "123 Shiny Street" },
                    new ProfileUser{ User_ID = "002", Login = "Beatrice", Address = "456 Sleepy Hill" },
                    new ProfileUser{ User_ID = "003", Login = "Celine", Address = "789 Rover Dome" },
                };
                tmp[0].SetValue(ProfileUserExtras.UserProperty, new Operator { RelatedUser = tmp[0], OperatorCodename = "Birdie", PermissionLevel = 111 });
                tmp[1].SetValue(ProfileUserExtras.UserProperty, new Operator { RelatedUser = tmp[1], OperatorCodename = "Twin", PermissionLevel = 222 });
                tmp[2].SetValue(ProfileUserExtras.UserProperty, new Operator { RelatedUser = tmp[2], OperatorCodename = "Trident", PermissionLevel = 333 });
                return tmp;
            }
        }
    }
    public class ProfileUser : DependencyObject
    {
        public string User_ID { get; set; }
        public string Login { get; set; }
        public string Address { get; set; }
        //- Operator User {get{}} -- does NOT exist here
    }
    public class Operator
    {
        public ProfileUser RelatedUser { get; set; }
        public string OperatorCodename { get; set; }
        public int PermissionLevel { get; set; }
    }
    
    public static class ProfileUserExtras
    {
        public static readonly DependencyProperty UserProperty = DependencyProperty.RegisterAttached(
            "User",             // the name of the property
            typeof(Operator),   // property type
            typeof(ProfileUserExtras), // the TARGET type that will have the property attached to it
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender) // whatever meta you like
        );
    }
    }
