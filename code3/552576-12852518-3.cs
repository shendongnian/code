    [HttpPost] 
    public ActionResult GetLocations(BoundingBoxRequest request) 
    { 
        // do something with boxes and return some json 
    } 
    public class BoundingBoxRequest
    {
        public IList<BoundingBox> Boxes { get; set; }
    }
