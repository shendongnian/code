    using Windows.Storage.Streams;
    using System.Text;
    using Windows.Web.Http;
    // in some async function
    Uri uri = new Uri("http://something" + query);
    HttpClient httpClient = new HttpClient();
    IBuffer buffer = await httpClient.GetBufferAsync(uri);
    string response = Encoding.UTF8.GetString(buffer.ToArray(), 0, (int)(buffer.Length- 1));
    // parse here
    httpClient.Dispose();
