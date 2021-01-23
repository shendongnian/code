    [HttpGet]
    [Route("api/projects")]
    private IHttpActionResult GetCount()
    {
        return Ok(db.Projects.Count());
    }
