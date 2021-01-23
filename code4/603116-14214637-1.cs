    public class HomeController : Controller
    {
        public FileResult Index()
        {
            FileStreamResult fileResult = new FileStreamResult(GetZippedStream(), System.Net.Mime.MediaTypeNames.Application.Zip);
            fileResult.FileDownloadName = "result" + ".zip";
            return fileResult;
        }
        private static Stream GetZippedStream()
        {
            byte[] fileBytes = Encoding.ASCII.GetBytes("abc");
            string returnFileName = "something";
            MemoryStream fileStream = new MemoryStream(fileBytes);
            MemoryStream resultStream = new MemoryStream();
            using (ZipFile zipFile = new ZipFile())
            {
                zipFile.AddEntry(returnFileName, fileStream);
                zipFile.Save(resultStream);
            }
            resultStream.Position = 0;
            return resultStream;
        }
    }
