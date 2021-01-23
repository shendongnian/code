    public class CustomPolicy : System.Web.Http.WebHost.WebHostBufferPolicySelector
    {
        public override bool UseBufferedInputStream(object hostContext)
        {
            return false;
        }
    }
