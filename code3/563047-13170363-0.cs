    // GET api/Woms           
    //public IEnumerable<Wom> GetWoms()
    public HttpResponseMessage GetWoms()
    {
      //return  db.Woms.Include("Owner").AsEnumerable(); 
      return Request.CreateResponse(HttpStatusCode.OK, new { woms = Include("Owner").AsEnumerable() });
    }
