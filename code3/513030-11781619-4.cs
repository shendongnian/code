    public IEnumerable<ProjectComments> GetLivingComments() {
         return this.ProjectComments != null 
             ? this.ProjectComments.Where(m => !m.IsDeleted) 
             : null;
    }
