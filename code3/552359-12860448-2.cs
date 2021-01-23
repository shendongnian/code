    public class SomeController: Controller
    {
        public ActionResult SomeAction() 
        {
            string path = FilePath + id + ".pdf";
            if (!File.Exists(path))
            {
                return HttpNotFound();
            }
            byte[] pdf = System.IO.File.ReadAllBytes(path);
            System.IO.File.Delete(path);
            return File(pdf, "application/pdf", Path.GetFileName(path));
        }
    }
