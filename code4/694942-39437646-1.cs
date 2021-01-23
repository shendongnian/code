    using System;
    using System.Dynamic;
    using Nancy;
    using Nancy.Extensions;
    using Newtonsoft.Json;
    
    Post["/apiurl"] = p => {
    	dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(Request.Body.AsString());
    
    	//Now you can access the object using its properties
    	return Response.AsJson((object)new { a = obj.Prop1 });
    }
