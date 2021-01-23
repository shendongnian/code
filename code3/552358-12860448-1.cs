    public class SomeController: Controller
    {
        public ActionResult SomeAction() 
        {
            return Redirect("~/_PDFLoader.aspx?Path=" + Url.Encode(FilePath + id) + ".pdf"");
        }
    }
