    public class ServiceManager{
        public static CalculatedData SomeMethod()
        {
             var client = GetClient();
             try
             {
                 return client.SomeMethod();
             }
             catch(Exception ex)
             {
                 //Handle Error
             }
             finally
             {
                 if(client.State == System.ServiceModel.CommunicationState.Opened)
                    client.Close();
             } 
        }
        private static SomeClient GetClient()
        {
             return new ServiceClient();
        }
    } 
