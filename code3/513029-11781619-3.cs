    public IEnumerable<ProjectComments> LivingComments {
       get {
          return this.ProjectComments != null 
             ? this.ProjectComments.Where(m => !m.IsDeleted) 
             : null;
       }
    }
