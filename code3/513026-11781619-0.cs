    public IEnumerable<ProjectComments> LivingComments {
       get {
          return this.ProjectComments.Where(m => !m.IsDeleted);
       }
    }
