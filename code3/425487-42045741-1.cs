  	    [RoutePrefix("api/values")]
		public class ValuesController : ApiController
		{
			public string Get()
			{
				return "simple get";
			}
	 
			[Route("geta")]
			public string GetA()
			{
				return "A";
			}
	 
			[Route("getb")]
			public string GetB()
			{
				return "B";
			}
       }
