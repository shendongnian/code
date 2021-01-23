    public RealRepository : IRepository
    {
        public void SaveInfo ()
        {
            using (CIHEntities _dbContext = new CIHEntities())
            {
                AuditInfoEntity aie = new AuditInfoEntity();
                aie.ActionDescription = this.ActionDescription;
                aie.ActionWhen = DateTime.Now;
                if (this.ActionWho != null)
                {
                    aie.ActionWho = this.ActionWho;
                }
                else
                {
                    aie.ActionWho = "Not Specified";
                }
                aie.ProjectAssoc = _dbContext.ProjectEntity
                    .Where(r => r.Id == this.Project.Id)
                    .First();
                _dbContext.SaveChanges();
            }
        }
    }
