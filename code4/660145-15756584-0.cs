    public class FileHandler {
        public string SiteRoot { get; set; }
        // or..
        public FileHandler(string siteRoot) {
            SiteRoot = siteRoot;
        }
    }
    
    FileHandler fileHandler = new FileHandler() { SiteRoot = Server.MapPath("~") };
    // or..
    FileHandler fileHandler = new FileHandler(Server.MapPath("~"));
