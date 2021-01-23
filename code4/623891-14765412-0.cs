    public class Your_Page_Name_Here : Page {
        /* public or */ protected string linkPatches;
        public void Page_Load(/*etc*/) {
            linkPatches = "PageProcessor.aspx?Page=Patches.aspx&system=" + Request.QueryString["system"];
        }
    }
