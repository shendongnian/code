    public IQueryable<Job> GetJobsByJobNum(string JobNum)
        {
            var query = ((from j in this.ObjectContext.Jobs.Include("JobHeadings").Include("JobContracts").Include("JobTags").Include("JobMarket")
                          where j.JobNumber == JobNum
                          select j) as ObjectQuery<Job>); 
            return query;
        }
