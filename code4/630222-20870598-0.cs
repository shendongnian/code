    public class AirPlayService : Service
    {
        public object Get(Movie request)
        {
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ( "Movies", request.Name);
    
            var file = new FileInfo(fileName);
            return new HttpResult(file, asAttachment:false); 
