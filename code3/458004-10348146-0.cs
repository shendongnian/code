	WebClient client = new WebClient();
	JavaScriptSerializer serializer = new JavaScriptSerializer();
	var data = serializer.Serialize(new {Name = "Ali", Title = "Ostad"});
	client.Headers[HttpRequestHeader.ContentType] = "application/json";
	var downloadString = client.UploadString("http://localhost:59174/api/values", data); // value is "Ali"
