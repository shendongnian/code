    public class FilesController : Controller
    {  
       public ActionResult Download(string fileId)
       {
         var fullFilePath=FileService.GetFullPath(fileId);  // get the path to file
         return File(fullFilePath,"application/pdf","yourDownLoadName.pdf");  
       }
    }
