    [RoutePrefix("api/car")]
    public class CarController: ApiController{
    
        [HTTPGet]
        [Route("")]
        public virtual async Task<ActionResult> GetAll(){
        
        }
    
    }
