    public class BaseApiController : ApiController
    {
        public readonly KiaEntities Db = KiaEntities.Get();
    }
    public class ColorsController : BaseApiController
    {
        // GET api/colors
        [Queryable]
        public IEnumerable<ColorViewModel> Get()
        {
            var colors = Db.Colors;
            return Mapper.Map<IEnumerable<ColorViewModel>>(colors);
        }
    }
