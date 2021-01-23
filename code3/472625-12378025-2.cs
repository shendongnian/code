    class BusinessUnit
        {
            public int BusinessUnitID { get; set; }
            public string BusinessName { get; set; }
            public BusinessUnit ParentBusinessUnit { get; set; }
    
            public override string ToString()
            {
                return BusinessUnitID + " " + BusinessName + " " + ParentBusinessUnit;
            }
        }
    
        class User
        {
            public int UserID { get; set; }
            public string Firstname { get; set; }
    
            public override string ToString()
            {
                return UserID + " " + Firstname;
            }
        }
    
        class UserPermissions
        {
            public BusinessUnit BusinessUnit { get; set; }
            public User User { get; set; }
    
            public override string ToString()
            {
                return BusinessUnit + " " + User;
            }
        }
    
        class SOBUProblem
        {
            static List<BusinessUnit> BUs = new List<BusinessUnit>();
            static List<User> Users = new List<User>();
            static List<UserPermissions> UPs = new List<UserPermissions>();
    
            static void Main()
            {
                //AutoInitBU();
                InitBU();
                InitUsers();
                InitUPs();
                //Dump(BUs);
                //Dump(Users);
                //Dump(UPs);
                //SpitTree(BUs[2]);
                int userID = 1;
                foreach (var BU in GetPermissions(userID))
                    Console.WriteLine(BU.BusinessName);
    
            }
            //Gets the lsit of permissions for this user
            static IEnumerable<BusinessUnit> GetPermissions(int userID)
            {
                //create a permission tree result set object
                List<BusinessUnit> permissionTree = new List<BusinessUnit>();
    
                //Get the list of records for this user from UserPermissions table
                IEnumerable<UserPermissions> userPermissions = from UP in UPs
                                             where UP.User.UserID == userID
                                             select UP;
    
                //for each entry in UserPermissions, build the permission tree
                foreach (UserPermissions UP in userPermissions)
                {
                    BuildPermissionTree(UP.BusinessUnit, permissionTree);
                }
                
                return permissionTree;
            }
    
            //recursive query that drills the tree.
            static IEnumerable<BusinessUnit> BuildPermissionTree(BusinessUnit pBU,List<BusinessUnit> permissionTree)
            {
                permissionTree.Add(pBU);
    
                var query = from BU in BUs
                            where BU.ParentBusinessUnit == pBU
                            select BU;
    
                foreach (var BU in query)
                {
                    BuildPermissionTree(BU,permissionTree);
                }
                return permissionTree;
            }
    
            static void Dump<T>(IEnumerable<T> items)
            {
                foreach (T item in items)
                {
                    Console.WriteLine(item.ToString());
                }
            }
    
            static void InitBU()
            {
                BusinessUnit BURoot = new BusinessUnit() { BusinessUnitID = 1, BusinessName = "BusinessUnitA" };
                BUs.Add(BURoot);
                BusinessUnit BUlevel11 = new BusinessUnit() { BusinessUnitID = 2, BusinessName = "BusinessUnitB", ParentBusinessUnit = BURoot };
                BusinessUnit BUlevel12 = new BusinessUnit() { BusinessUnitID = 3, BusinessName = "BusinessUnitC", ParentBusinessUnit = BURoot };
                BUs.Add(BUlevel11);
                BUs.Add(BUlevel12);
                BusinessUnit BUlevel121 = new BusinessUnit() { BusinessUnitID = 4, BusinessName = "BusinessUnitD", ParentBusinessUnit = BUlevel12 };
                BusinessUnit BUlevel122 = new BusinessUnit() { BusinessUnitID = 5, BusinessName = "BusinessUnitE", ParentBusinessUnit = BUlevel12 };
                BUs.Add(BUlevel121);
                BUs.Add(BUlevel122);
                BusinessUnit BUlevel1211 = new BusinessUnit() { BusinessUnitID = 6, BusinessName = "BusinessUnitF", ParentBusinessUnit = BUlevel121 };
                BUs.Add(BUlevel1211);
                BusinessUnit BUlevel111 = new BusinessUnit() { BusinessUnitID = 7, BusinessName = "BusinessUnitG", ParentBusinessUnit = BUlevel11 };
                BUs.Add(BUlevel111);
            }
    
            static void AutoInitBU()
            {
                BusinessUnit BURoot = new BusinessUnit() { BusinessUnitID = 1, BusinessName = "BusinessUnitA" };
                BUs.Add(BURoot);
                Dictionary<int, string> transTable = new Dictionary<int, string>() {{2,"B"},{3,"C"} };
                //Create Child nodes
                for (int i = 0; i < 2; i++)
                {
                    BUs.Add(new BusinessUnit() { BusinessUnitID = i + 2, BusinessName = "BusinessUnit" + transTable[i+2],ParentBusinessUnit =  BUs[i]});
                }
            }
    
            static void InitUsers()
            {
                Users.Add(new User() {UserID = 1,Firstname="User1" });
            }
    
            static void InitUPs()
            {
                UPs.Add(new UserPermissions() { BusinessUnit = BUs[1], User = Users[0] });
                UPs.Add(new UserPermissions() { BusinessUnit = BUs[2], User = Users[0] });
            }
        }
