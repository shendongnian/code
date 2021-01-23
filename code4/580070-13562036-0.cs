        [HttpGet]
        [ActionName("GetStatesByID")]    
        public ODataResult<DataAccess.Model.State> GetStatesByID(ODataQueryOptions options,int id)
        {
            var states = this.Repository.GetAllStatesByCountry(id)
                                        .AsQueryable<DataAccess.Model.State>();
            long count = states.Count();
            if(count == 0)
              return null;
            var results = (options.ApplyTo(states) as IQueryable<DataAccess.Model.State>);
            return new ODataResult<DataAccess.Model.State>(results, null, count);
        }
