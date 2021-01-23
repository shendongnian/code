    public IQueryable<T> QueryableEntities
    {
        get
        {
            if (typeof(T).Equals(typeof(Model.Competition)))
            {
                return this.ConvertToCompetitionList(
                      this.GetTable<Storage.Competition>()).AsQueryable() as IQueryable<T>;
            }
             else if(typeof(T).Equals(typeof(Model.Submission)))
            {
                return this.ConvertToSubmissionList(
                       this.GetTable<Storage.CompetitionEntry>()).AsQueryable() as IQueryable<T>;
            }
        }
    }
