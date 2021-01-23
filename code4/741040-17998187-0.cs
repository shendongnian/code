    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public static class UserHandler
        {
            private static  List<User> Users = new List<User>();
    
            public static void AddNewUser(User user)
            {
                Users.Add(user);
            }
    
            public static void RemoveUser(User user)
            {
                Users.Remove(user);
            }
    
            public static User GetUserById(int id)
            {
                if(Users.Exists(x => x.userId == id))
                {
                    return Users.Find(user => user.userId == id);
                }
    
                return null;
            }
        }
    
        public class User
        {
            public int userId { get; set; }
            public string userName { get; set; }
    
            public User(int id, string name)
            {
                this.userId = id;
                this.userName = name;
            }
        }
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                var _user = new User(1,"user2252502");
                UserHandler.AddNewUser(_user);
                MessageBox.Show(UserHandler.GetUserById(1).userName);
                Form2 form2 = new Form2();
            }
           
        }
    
        public partial class Form2 : Form
        {
            public Form2()
            {
                MessageBox.Show(UserHandler.GetUserById(1).userName);
            }
        }
    }
