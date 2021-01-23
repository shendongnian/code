    public class Project
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public override bool Equals(Object obj) 
        {
            if (obj is Project)
            {
                var that = obj as Project;
                return this.Id == that.Id && this.Name == that.Name;
            }
 
            return false; 
        }
    }
