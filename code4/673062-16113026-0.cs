    public class TestBase<TController, TObject, TRepo>
        where TController : IRMCController<TObject>
        where TRepo : class, IRMCRepository
        
    {
        public Mock<TRepo> Repo { get; set; }
    }
