	public class Http404NotFoundException : HttpResponseException
	{
		public Http404NotFoundException()
			: base(new HttpResponseMessage(HttpStatusCode.NotFound)) { }
	}
