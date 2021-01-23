    public class LoginService : Service
    {   
        public object Get(UserLogin request)
        {
            var response = new UserLoginResponse { Result = request };
            return response;
        }
    }
