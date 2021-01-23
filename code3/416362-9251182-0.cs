    public class UserController
    {
        public void CreateUser(UserViewModel user)
        {
            bool isUserValid=ValidateUser(user);
            if(isUserValid)
            {
                UserEntity theEntity=new UserEntity(user);
                _userRepository.Create(theEntity);
            }
            else
            {
                throw new InvalidUserException("This user isn't valid");
            }
        }
    }
