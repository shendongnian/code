    public class A_View : AbstractIndexCreationTask<DocA, ViewA>
    {
        public A_View()
        {
            Map = docs => from doc in docs
                          select new ViewA
                          {
                              Id = doc.Id,
                              Name = doc.Name,
                              CurrencyName = doc.Currency.Name
                          };
    
            // Top-level properties on ViewA that match those on DocA
            // do not need to be stored in the index.
            Store(x => x.CurrencyName, FieldStorage.Yes);
        }
    }
