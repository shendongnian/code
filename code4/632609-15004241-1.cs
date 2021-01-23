    [HttpGet, ActionName("EMPTY")]
    public IEnumerable<Patient> All()
    [HttpGet, ActionName("EMPTY")]
    public Patient ByIndex(int index)
    [HttpPost, ActionName("EMPTY")]
    public HttpResponseMessage Add([FromBody]Patient patient)
    [HttpPost, ActionName("save")]
    public void Save(int not_used = -1)
