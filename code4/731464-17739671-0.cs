    [System.Xml.Serialization.XmlRoot("books")]
	public class books 
	{
	    public int bookNum { get; set; }
	    public class book {
	        public string name { get; set; }
	        public class record {
	            public string borrowDate { get; set; }
	            public string returnDate { get; set; }
	        }
	        public record[] records { get; set; }
	    }
	    public book[] books { get; set; }
	}
