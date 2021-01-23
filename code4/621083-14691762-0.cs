    void Main()
    {
    	string responseData = "[{\"FirstName\":\"George\",\"LastName\":\"Clooney\"},{\"FirstName\":\"Brad\",\"LastName\":\"Pitt\"}]";
    
        Report[] reports = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Report[]>(responseData);
    	
        
    	reports.Dump(); // <-- Dump() is  another LinqPad extension method that can be ignored.
    }
    
    
    public class Report
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
