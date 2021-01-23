    [ServiceContract]
    interface IUploader
    {
    [WebInvoke(UriTemplate = "FileUpload?public_id={public_id}&tags={tags}",
      Method = "POST",
      ResponseFormat = WebMessageFormat.Json)]
      UploadImageResult UploadImage(Stream fileContents, string public_id, string tags);
    }
    
    public class Uploader : IUploader
    {
    public UploadImageResult UploadImage(Stream fileContents, string public_id, string tags)
    {
    try
    {
    byte[] buffer = new byte[32768];
    FileStream fs = File.Create(Path.Combine(rootFolderPath, @"test\test.jpg"));
    int bytesRead, totalBytesRead = 0;
    do
    {
    bytesRead = fileContents.Read(buffer, 0, buffer.Length);
    totalBytesRead += bytesRead;
    fs.Write(buffer, 0, bytesRead);
    } while (bytesRead > 0);
    
    fs.Close();
    }
    catch(Exception ex)
    {
    ...
    }
    }
    }
