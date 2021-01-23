    public class AController : ApiController
    {
        private readonly BController _bController;
        public AController(
        BController bController)
        {
            _bController = bController;
        }
        public httpMethod{
        var result =  _bController.OtherMethodBController(parameters);
        ....
        }
    }
