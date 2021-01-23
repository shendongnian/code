    public partial class _Default : System.Web.UI.Page{
        //We will initialize this variable a bit later 
        //for example from URL parameter ?userType=1 or something like that
        private UserAccessType _currentUserAccess;
        //Ideally, dictionary should be a member of a class
        //I left a simple dictionary just to avoid over-complicaation
        private readonly Dictionary<UserAccessType, MenuItemsPolicy> _userMenuItems = new Dictionary<UserAccessType, MenuItemsPolicy>();
        protected override void OnInit(EventArgs e){
            //Associating our user types with Menu Items
            _userMenuItems.Add(UserAccessType.Administrator, new AdministratorMenuItems());
            _userMenuItems.Add(UserAccessType.Requestor, new RequestorMenuItems());
            //Init the Current User / Access Type. For example, you can read the value from Request["UserType"]
            //Here I've just assigned a value
            _currentUserAccess = UserAccessType.Administrator;
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e){
            BuildMenu();
        }
        private void BuildMenu(){
            mainMenu.Items.Clear();
            var menuItems = GetMenuItems();
            foreach(var item in menuItems){
                mainMenu.Items.Add(item);
            }
        }
        private List<MenuItem> GetMenuItems(){
            MenuItemsPolicy currentPolicy = _userMenuItems[_currentUserAccess];
            return currentPolicy.GetMenuItems();
        }
    }
