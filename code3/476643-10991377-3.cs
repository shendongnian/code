	[System.Web.Services.WebMethod]
	 public static string AcceptData(object jsonData)
	 {
		 Customer newCust =(Customer)JsonConvert.DeserializeObject(jsonData.ToString(),typeof(Customer));
		 return "Server response: Hello "+newCust.FirstName;
	 }
