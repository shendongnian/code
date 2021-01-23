    <pre><code>public class AddressResponse
    {
	    public List&lt;Address&gt; Results { get; set; }
	    public string Status { get; set; }
    }</code></pre>
    <pre><code>public class Address
    {
	    public List&lt;AddressComponent&gt; AddressComponents { get; set; }
	    public string FormattedAddress { get; set; }
	    public Geometry Geometry { get; set; }
	    public string PlaceId { get; set; }
	    public List&lt;string&gt; Types { get; set; }
    }</code></pre>
