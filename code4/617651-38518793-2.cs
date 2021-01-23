    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Mime;
    
    namespace picpaste1
    {
      class Program
      {
        static void Main(string[] args)
        {
          var fi = new FileInfo(@"path\to\picture.png");
          using (var client = new HttpClient())
          using (var mfdc = new MultipartFormDataContent())
          using (var filestream = fi.OpenRead())
          using (var filecontent = new StreamContent(filestream))
          {
    
            filecontent.Headers.ContentDisposition = 
              new ContentDispositionHeaderValue(DispositionTypeNames.Attachment)
            {
              FileName = fi.Name,
              Name = "upload"
            };
            filecontent.Headers.ContentType = new MediaTypeHeaderValue("image/png");
    
            mfdc.Add(new StringContent("7168000"), "MAX_FILE_SIZE");
            mfdc.Add(filecontent);
            mfdc.Add(new StringContent("9"), "storetime");
            mfdc.Add(new StringContent("no"), "addprivacy");
            mfdc.Add(new StringContent("yes"), "rules");
            var uri = "http://picpaste.com/upload.php";
            var res = client.PostAsync(uri, mfdc).Result;
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(res.Content.ReadAsStringAsync().Result);
            uri = doc.DocumentNode.SelectNodes("//td/a").First()
              .GetAttributeValue("href","NOT FOUND");
            res = client.GetAsync(uri).Result;
            doc.LoadHtml(res.Content.ReadAsStringAsync().Result);
            var foo = doc.DocumentNode.SelectNodes("//div[@class='picture']/a").First()
              .GetAttributeValue("href","NOT FOUND");
            Console.WriteLine("http://picpaste.com{0}", foo);
            Console.ReadLine();
          }
        }
      }
    }
