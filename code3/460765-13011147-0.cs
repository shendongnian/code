     public class MyConnectionFactory : IConnectionIdGenerator
        {
            public string GenerateConnectionId(IRequest request)
            {
                return MyUserManager.Instance.CurrentUserID.ToString();
            }
        }
