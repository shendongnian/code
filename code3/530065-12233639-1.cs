    public class Page {
        public Navigation PageNavigation { get; private set; }
        public string FilePath { get; set; }
        public int RoleNumber { get; set; }    
        public Page() {
            PageNavigation = new Navigation();
        }
    }
	
