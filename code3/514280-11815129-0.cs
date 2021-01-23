    public interface iUserInfo {
        //the client (any class that uses the interface) knows that can get the UserName
        //and the UserAge, it doesn't need to know how...
        string getUserName(int userId);
        string getUserAge(string username);
    }
    public class UserDb implements iUserInfo
    {
        string getUserName(int userId)
        {
            //this implementation will connect to database to get the data
        }
    }
    public class UserTxtFile implements iUserInfo
    {
        string getUserName(int userId)
        {
            //this implementation will read from a text file to get the data
        }
    }
