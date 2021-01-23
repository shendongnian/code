    //using System.Runtime.Serialization.Json;
	
    public static dynamic Deserialize(string content)
 	{
	    return new System.Web.Script.Serialization.JavaScriptSerializer().DeserializeObject(content);
	}
 
	var f = Deserialize(json);
	List<Name> list = new List<Name>();
	
	foreach(var item1 in (Dictionary<string, object>) f)
	{
		Dictionary<string, object> item2 = (Dictionary<string, object>) item1.Value;
		
		list.Add( new Name(){
			id = (int) item2["id"],
			name = (string) item2["name"],
			age = (int) item2["age"]
		});				
		
	}
