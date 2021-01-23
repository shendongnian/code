    public interface ISecuredService
    {
       public UserCredentials Credentials { get; set; }
    }
    /// <summary>
    /// Proxy for executing generic UserCredentials  secured service methods
    /// </summary>
    public class SecuredServiceProxy
    {
        /// <summary>
        /// Execute service method and get return value
        /// </summary>
        /// <typeparam name="C">Type of service</typeparam>
        /// <typeparam name="T">Type of return value</typeparam>
        /// <param name="credentials">Service credentials</param>
        /// <param name="action">Delegate for implementing the service method</param>
        /// <returns>Object of type T</returns>
        public static T Execute<C, T>(UserCredentials credentials, Func<C, T> action) where C : class, ICommunicationObject, ISecuredService, new()
        {
            C svc = null;
    
            T result = default(T);
    
            try
            {
                svc = new C();
                svc.Credentials = credentials;
    
                result = action.Invoke(svc);
    
                svc.Close();
            }
            catch (FaultException ex)
            {
                // Logging goes here
                // Service Name: svc.GetType().Name
                // Method Name: action.Method.Name
                // Duration: You could note the time before/after the service call and calculate the difference
                // Exception: ex.Reason.ToString()
    
                if (svc != null)
                {
                    svc.Abort();
                }
    
                throw;
            }
            catch (Exception ex)
            {
                // Logging goes here
    
                if (svc != null)
                {
                    svc.Abort();
                }
    
                throw;
            }
    
            return result;
        }
    }
