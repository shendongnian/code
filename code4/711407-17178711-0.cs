        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.Http;
    namespace AngularFun.Controllers
    {
        class MyMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
        {
            public MyMultipartFormDataStreamProvider(string path)
                : base(path)
            {
            }
            public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
            {
                string fileName;
                if (!string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName))
                {
                    fileName = headers.ContentDisposition.FileName;
                }
                else
                {
                    fileName = Guid.NewGuid().ToString() + ".data";
                }
                return fileName.Replace("\"", string.Empty);
            }
        }
    }
