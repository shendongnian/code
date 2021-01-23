    public class Project
    {
        public virtual int Id { get; set; }
    
        public virtual string Name { get; set; }
        public override bool Equals(object o)
        {
            var result = false;
            var project = o as Project;
            if (project != null)
            {
                result = Id == project.Id;
                result &= Name.Equals(project.Name);
                return result;
            }
            return false;
        }
    }
