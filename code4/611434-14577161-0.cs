    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate="TestMethod/")]
        Stream TestMethod(Stream input);
    }
    public class MyService: IMyService
    {
        Stream IMyService.TestMethod(Stream input)
        {
            byte[] buffer = new byte[10000];
            int bytesRead, totalBytesRead = 0;
            this.currentResponseOffset = 0;
            do
            {
                bytesRead = input.Read(buffer, 0, buffer.Length);
                totalBytesRead += bytesRead;
            } while (bytesRead > 0);
            input.Close();
            return new MemoryStream(buffer, 0, totalBytesRead);
        }
    }
