    public class Dependencyon : ActionFilterAttribute {
        
        string field;
          
        public Dependencyon (string field){
            this.field = field;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //check whether field is populated and redirect if not?    
        }
    }
