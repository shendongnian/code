    public class UploadController : ApiController
        {
    public masterEntities context = new masterEntities();
    public ImgEntitySet imgEntity = new ImgEntitySet();
    public async Task<HttpResponseMessage> PostRawBufferManual()
    {
    MultipartFormDataStreamProvider streamProvider = new MultipartFormDataStreamProvider("~/App_Data");
    MultipartFileStreamProvider dataContent = await Request.Content.ReadAsMultipartAsync(streamProvider);
                foreach (HttpContent data in dataContent.Contents)
                {
                    string fileName = data.Headers.ContentDisposition.Name;
                    byte[] n = await data.ReadAsByteArrayAsync();
                    string m = Encoding.ASCII.GetString(n);
                    int z = int.Parse(m);
                    imgEntity.UID = z;
                    break;
                }
                foreach (HttpContent data in dataContent.Contents)
                {
                    string fileNamePicture = data.Headers.ContentDisposition.Name;
                    if (fileNamePicture == "picture")
                    {
                        byte[] b = await data.ReadAsByteArrayAsync();
                        imgEntity.Image = b;
                    }
                }
    
                context.ImgEntitySet.Add(imgEntity);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK );
            }
    }
