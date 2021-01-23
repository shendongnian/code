    public interface ITechnology<TQuery, TSearch>
    {
        TQuery Query(TQuery queryObject);
        TSearch Search(TSearch saerchObject);
    }
    public interface ISolrTechnology : ITechnology<SolrQuery, SolrSearch>
    {
    }
    public class Solr : ISolrTechnology
    {
        public SolrQuery Query(SolrQuery queryObject) {
            // ...
        }
        public SolrSearch Search(SolrSearch searchObject) {
            // ...
        }
    }
