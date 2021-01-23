    public class ContestsController : ApiController
    {
        //Ninject wouldn't inject this CTOR argument resulting in the error
        public ContestsController(IContestEntryService contestEntryService)
        {
