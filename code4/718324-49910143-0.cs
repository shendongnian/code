    [HttpGet]
    [Route("api/projects")]
    public IHttpActionResult GetCount()
    {
        return Ok(db.Projects.Count());
    }
