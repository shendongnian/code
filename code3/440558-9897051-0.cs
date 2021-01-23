    public class UserFunctions
    {
        private enum Info
        {
            LoginSuccess = 401,
            NoMatchPasswordEmail = 402,
            InvalidEmail = 403,            
        };
        public delegate void LoginAttemptArgs(object sender, Info result, int CustomerID);//Define the delegate paramters to pass to the objects registered to the event.
        public event LoginAttemptArgs LoginAttempt;//The event name and what delegate to use.
        public void TryLogin(string email, string password)
        {
            bool isValidEmail = Validation.ValidEmail(email);
            if (isValidEmail == false)
            {                
                OnLoginAttempt(Info.InvalidEmail, -1);
            }        
            Customers customer = new Customers();
            customer.email = email;
            customer.password = password;
            DataTable dtCustomer = customer.SelectExisting();
            if (dtCustomer.Rows.Count > 0)
            {                
                int customerID = int.Parse(dtCustomer.Rows[0]["CustomerID"].ToString());
                OnLoginAttempt(Info.LoginSuccess, customerID);
            }
            else
            {                      
                OnLoginAttempt(Info.NoMatchPasswordEmail, -1);
            }
        }
        private void OnLoginAttempt(Info info, int CustomerID)
        {
            if (LoginAttempt != null)//If something has registered to this event
                LoginAttempt(this, info, CustomerID);
        }
    }
