        // Specify the HttpHead attribute to avoid getting the MethodNotAllowed error.
        [HttpGet, HttpHead]
        [Route("Atms", Name = "AtmsList")]
        public IHttpActionResult Get(string sort="id", int page = 1, int pageSize = 5)
        {
            try
            {
                // get data from repository
                var atms =  _atmRepository.GetAll().AsQueryable().ApplySort(sort);
				// ... do some code to construct pagingInfo etc.
				// .......
                // set paging info in header.
                HttpContext.Current.Response.Headers.Add(
                  "X-Pagination", JsonConvert.SerializeObject(paginationHeader));
				// ...
                return Ok(pagedAtms));
            }
            catch (Exception exception)
            {
				//... log and return 500 error
            }
        }
