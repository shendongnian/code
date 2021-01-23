    public class OutgoingWebResponseWrapper: OutgoingWebResponseWrapperBase
    {
        private readonly OutgoingWebResponse _response;
        public OutgoingWebResponseWrapper(OutgoingWebResponse response)
        {
            _response = response;
        }
    
        public override ActionResult AsActionResult()
        {
            return _response.AsActionResult();
        }
    }
