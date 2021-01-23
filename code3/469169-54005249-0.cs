    	[HttpGet]
		public ActionResult<YOUROBJECT> Get()
		{
			return StatusCode(304);
		}
