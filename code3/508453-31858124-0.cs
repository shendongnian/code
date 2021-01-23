    public class 1 {
        public void method(){
            //do stuff
        }
    }
    public class 2 {
        public void method2(){
            dynamic users = BLClass.MYBLMethod();
            List<string> usernames = BLClass.MYBLSecondMethod();
            foreach (string username in usernames)
            {
                 1.method(users[username]);
             }
        }
     }
