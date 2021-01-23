    [ServiceContract]
    public interface IMasOperations
    {
        [OperationContract]
        CoAuthorSearchResult ExtractCoAuthorsFromAuthor(long AuthorCellId, uint LevelsToExtract);
    }
    public class CoAuthorSearchResult
    { }
    public class MyProxy
    { 
        public CoAuthorSearchResult GetProxyData()
        {
            return new CoAuthorSearchResult();
        }
    }
