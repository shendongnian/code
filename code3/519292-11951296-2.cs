    public class Document{
    [SolrUniqueKey("id")]
    public integer Id { get; set; }
    [SolrField("text")]
    public ICollection<string> texts { get; set; }
