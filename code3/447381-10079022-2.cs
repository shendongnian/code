    public class SalesUser
    {
        public static explicit operator (User user)
        {
            //perform conversion of User to SalesUser
        }
    }
    //the above operator permits the following:
    mySalesUser = (SalesUser)myUser;
