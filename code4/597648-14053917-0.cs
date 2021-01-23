    using (var client = new WebClient())
    {
        using (var stream = client.OpenRead("http://*.com/download.php?id=1"))
        {
            var disposition = client.ResponseHeaders["Content-Disposition"];
            if (disposition != null)
            {
                var cd = new ContentDisposition(disposition);
                if (!cd.Inline && !string.IsNullOrEmpty(cd.FileName))
                {
                    using (var outputStream = File.OpenWrite(cd.FileName))
                    {
                        stream.CopyTo(outputStream);
                    }
                }
            }
            else
            {
                // The web server didn't send a Content-Disposition response header
                // so we have absolutely no means of determining the filename
                // you will have to use some default value here if you want to store it
            }
        }
    }
