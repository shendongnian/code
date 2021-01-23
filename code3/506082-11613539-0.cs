    //----------------------
    //Response class
    public class Responce
    {
    	List<string> MyData {get;set;}
    	
    	public Response()
    	{
    		MyData = new List<string>();
    	}
    }
    
    //----------------------
    //create response
    var response = Response();
    MyData.Add("result 1");
    MyData.Add("result 2");
    
    //----------------------
    //and then later when you process it
    var data = responce.MyData
    foreach(string line in data)
    {
    	if(String.IsNullOrEmpty(line)
    		continue;
    		
    	//do your processing
    }
