    public class Page {
        public Navigation PageNavigation { get; private set; }
        public string FilePath { get; set; }
        public int RoleNumber { get; set; }    
        public Page() {
            PageNavigation = new Navigation();
        }
        public class Navigation {
            public string Menu { get; set; }
            public string Breadcrumbs { get; set; }
        }
    }
	
