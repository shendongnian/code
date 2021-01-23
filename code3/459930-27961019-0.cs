    public class FakeControllerContextWithMultiPartContentFactory
    {
        public static HttpControllerContext Create()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "");
            var content = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(new Byte[100]);
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "Foo.txt"
            };
            content.Add(fileContent);
            request.Content = content;
            return new HttpControllerContext(new HttpConfiguration(), new HttpRouteData(new HttpRoute("")), request);
        }
    }
