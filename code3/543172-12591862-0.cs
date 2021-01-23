        protected IRestResponse GetResponse(int a, int b)
		{
			var client = new RestClient
			{
				BaseUrl = "http://localhost:8888/api/FooController"
			};
			var request = new RestRequest
			{
				DateFormat = DataFormat.Xml.ToString(),
				Resource = "Add",
				Method = Method.GET
			};
			request.AddParameter("application/json",
				JsonSerializer.JsonSerialize(new {a, b}),
				ParameterType.RequestBody);
			return client.Execute(request);
		}
