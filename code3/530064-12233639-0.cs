    public class Navigation {
        public string Menu { get; set; }
        public string Breadcrumbs { get; set; }
    }
    public class Page : Navigation {
        public string FilePath { get; set; }
        public int RoleNumber { get; set; }    
    }
