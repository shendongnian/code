            // Read the file into a byte[] so we can delete it before responding
            byte[] bytes;
            using (var stream = new FileStream(path, FileMode.Open))
            {
                bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
            }
            File.Delete(path);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(bytes);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.Add("content-disposition", "attachment; filename=foo.bar");
            return result;
