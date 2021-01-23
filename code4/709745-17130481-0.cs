    var filecontent = new ByteArrayContent(System.IO.File.ReadAllBytes("C:\\Users\\XXXX\\Desktop\\Sample.xlsx"));
                var content = new MultipartContent("form-data", "AAAA");
                content.Headers.Add("X-Atlassian-Token", "nocheck");
                content.Headers.Add("charset", "UTF-8");
    
                filecontent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                {
                    Name="\"file\"",
                    FileName = "Attachment.xlsx"
                };
    
                filecontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                content.Add(filecontent);
