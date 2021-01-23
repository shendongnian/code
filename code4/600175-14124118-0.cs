    public class someclass
    { 
    	public string CompanyName { get; set; }
    	public string address { get; set; }
    	public string Alternativeaddress { get; set; }
    	public string CompanyNumber { get; set; }
    	public someclass(string name, string address, string address2, string number)
    	{
    		this.CompanyName=name;
    		this.address=address;
    		this.Alternativeaddress=address2;
    		this.CompanyNumber=number;
    	}
    }
