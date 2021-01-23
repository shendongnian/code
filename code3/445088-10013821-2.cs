    public class MyRemoteAttribute : RemoteAttribute
    {
         public MyRemoteAttribute() : base("CheckPrice","Kenmerk"){
             base.HttpMethod = "Post";
         }
         public override bool IsValid(object value){
               //recreate validation here
               //additionalfields can be found in HttpContext.Current.Request.Params
               return true;
         }
    }
