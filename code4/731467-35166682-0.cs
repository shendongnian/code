    public class books
    {
        public int bookNum { get; set; }
        public class book {
    	    public string name { get; set; }
        	public class record {
    	        public string borrowDate { get; set; }
    	        public string returnDate { get; set; }
    	    }
    		[XmlElement("record")]
    	    public record[] records { get; set; }
        }
    	[XmlElement("book")]
        public book[] allBooks { get; set; }
    }
