    public class CollectionPager
    {
        public CollectionPager()
        {
            List = new List<string>();
        }
    
        public List<string> List { get; private set; }
    }
    
    public interface IRetrieveListService
    {
        void RetrieveList(CollectionPager pager);
    }
    
    public class RetrieveListService : IRetrieveListService
    {
        public void RetrieveList(CollectionPager pager)
        {
            pager.List.Add("item1");
            pager.List.Add("item2");
        }
    }
    
    public class OtherService
    {
        private readonly IRetrieveListService retrieveListService;
    
        public OtherService(IRetrieveListService retrieveListService)
        {
            this.retrieveListService = retrieveListService;
        }
    
        public void SomeMethodToTest()
        {
            var collectionPager = new CollectionPager();
            retrieveListService.RetrieveList(collectionPager);
            // in your test collectionPager.Item contains: testItem1, testItem2
        }
    }
