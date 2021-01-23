    public class UserViewModel { 
       public UserViewModel(int userId) {
          UserToDisplay = UserRepository.GetUserById(userId);
       }
    
       public User UserToDisplay { get; set; }
    }
