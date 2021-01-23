    void Main()
    {
    	var XBLRegionalContents = new List<XBLRegionalContent>(){
    		new XBLRegionalContent { contentID = "a", ID = "aa" },
    		new XBLRegionalContent { contentID = "b", ID = "bb" },
    		new XBLRegionalContent { contentID = "a", ID = "cc" },
    		new XBLRegionalContent { contentID = "d", ID = "dd" }
    	};
    	
    	XBLRegionalContents.Dump();
    	
    	var qry = from c in XBLRegionalContents
    		group c by c.contentID into grouped
    		select new { xbl = XBLRegionalContents.Find(x => x.contentID == grouped.Key), regionCount = grouped.Count() };
    	
    	qry.Dump();
    }
    
    // Define other methods and classes here
    public class XBLRegionalContent{
    	public string contentID {get;set;}
    	public string ID {get;set;}
    }
