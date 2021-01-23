    void Main()
    {
    	var db = 	  @"<root>
    						<entities>
    							<entity id='1' name='tim'/>
    							<entity id='2' name='Gaui'/>
    						</entities>
    						<properties>
    							<property id='1' entityid='1' name='Age' value='46'/>
    							<property id='2' entityid='1' name='Country' value='Australia'/>
    							<property id='3' entityid='2' name='StackoverflowRep' value='17'/>
    						</properties>
    					</root>";
    	var doc = XElement.Parse(db);
    	var ents = from	e in doc.Descendants("entity")
    				select new Entity()
    				{
    					id = (int)e.Attribute("id"),
    					name = (string)e.Attribute("name"),
    					Properties = doc.Descendants("property")
    									.Where(p => (int)p.Attribute("entityid") == (int)e.Attribute("id"))
    									.Select( p => new { name = (string)p.Attribute("name") , value = (string)p.Attribute("value")})
    									.ToDictionary(k => k.name, v => v.value)
    				};
    	ents.Dump();				
    }
    
    
    public class Entity
    {
    	public int id {get;set;}
    	public string name {get;set;}
    	public IDictionary<string, string> Properties {get;set;}
    }
    
    // You can run this spike in LinqPad (language c# Program)
    
    // In this example I just have a simple master detail, and the assumtion is that the name/value pairs are strings. 
    // In a real app you probably would have another table with property types, something like...
    
    //<propertytypes>
    //	<propertytype id='1' Name='Country' type='string'>
    //  ....etc
    //	</propertytype>
    //</propertytypes>
    
    // and in the properties table you would join to this instead.
    // This would give you the data types, plus the ability to 
    // populate a list of allowed properties etc.
