    class LoginViewController
    {
        void Login (credentials)
        {
            service.AuthenticateAsync (credentials, LoginCompletedCallback);
            }
    
        }
        void LoginCompletedCallback ()
        {
            BeginInvokeOnMainThread (OnAuthenticateCompleteded);
        }
    }
