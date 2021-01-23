    public class QueryClass 
    {
    public string query { get; set; }
    }
    public ResponseModel messageProcessor(QueryClass query)
    {
      ResponseModel model=DoStuff(query.query);
      return model;
    }
