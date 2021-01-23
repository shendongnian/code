     class Program
    {
        
        static void Main(string[] args)
        {
            dynamic testObj = new ExpandoObject();
            test t = new test();
            t.GetSomething(testObj, "TestUserName");
            Console.WriteLine(testObj.CUser);
            Console.ReadLine();
        }
       
    }
    public class test
    {
        // This is my model
        public class sUser : DynamicModel
        {
            public sUser()
                : base("test",
                        "Users",
                        "UserId") { }
        }
        public void GetSomething(dynamic testObj, string user)
        {
            dynamic User = GetUser(user);
            testObj.CUser = User.FirstName + User.LastName;
           
        }
        public dynamic GetUser(string uName)
        {
            dynamic table = new sUser();
            var objUser = table.First(UserName: uName);
            return objUser;
        }
    }
