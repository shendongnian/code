    public class ProductController : BaseController
    {
        // GET api/Product/Get/5/43324
        [AcceptVerbs("GET")]
        [HttpGet]
        public ApiProduct Get(int id, [FromUri]int productId)
        {
             //// logic
        }
