    here a sample to pass list object to your webservice
    
        <%@WebService Language="c#" class="CustomObjectArrayWS"%>
    using System;
    using System.Collections;
    using System.Web.Services;
    using System.Xml.Serialization;
    public class CustomObjectArrayWS
    {
         	[WebMethodAttribute]
        	[XmlInclude(typeof(Address))]
        	public ArrayList GetAddresses ()
       	{
      		ArrayList al = new ArrayList();
      		Address addr1 = new Address("John Smith", "New York",12345);
      		Address addr2 = new Address("John Stalk", "San Fransisco", 12345);
      			
           		al.Add(addr1);
           		al.Add(addr2);
           		
          		return al;
     	}
    } 
    // Custom class to be added to the collection to be passed in //and out of the service
    public class Address
    {
     	public string name;
     	public string city;
     	public int zip; 	
     	// Default ctor needed by XmlSerializer
     	public Address()
     	{
     	}
     	public Address(string _name, string _city, int _zip  )
    	{ 
                        this.name = _name;
                        this.city = _city;
                         this.zip = _zip;
               }
           }
