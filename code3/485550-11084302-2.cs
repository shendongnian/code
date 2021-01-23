    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, 
    
                     ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestDemoServices:IRESTDemoServices
    {
        public string GetClientNameById(string Id)
        {
            Random r = new Random();
            string ReturnString="";
            int Idnum=Convert.ToInt32(id);
            for (int i = 0; i < Idnum; i++)
                ReturnString += char.ConvertFromUtf32(r.Next(65, 85));
    
            return ReturnString;
    
        }
    }
