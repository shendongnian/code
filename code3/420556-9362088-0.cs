    //Core DLL 
    
    public class Job
    {
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? CreatedDate { get; set; }  
        protected IList<File> _files = new List<File>();
        public virtual IEnumerable<File> Files
        {
            get { return _files; }
        }
    }
