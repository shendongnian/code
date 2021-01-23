            var isPasswordValid = PrincipalContext.ValidateCredentials(
                userName,
                password);
            // use ChangePassword to test credentials as it doesn't use caching, unlike ValidateCredentials
            if (isPasswordValid)
            {
                try
                {
                    user.ChangePassword(password, password);
                }
                catch (PasswordException ex)
                {
                    if (ex.InnerException != null && ex.InnerException.HResult == -2147024810)
                    {
                        // Password is wrong - must be using a cached password
                        isPasswordValid = false;
                    }
                    else
                    {
                        // Password policy problem - this is expected, as we can't change a password to itself for history reasons    
                    }
                }
                catch (Exception)
                {
                    // ignored, we only want to check wrong password. Other AD related exceptions should occure in ValidateCredentials
                }
            }
