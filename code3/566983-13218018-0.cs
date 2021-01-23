      public Project GetProjectyById(int id)
        {
            var context = new CoderaDBEntities() 
            return context.Projects.First(c => c.Id == id);       
        }
