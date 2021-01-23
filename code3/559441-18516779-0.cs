    var stream = service.HttpClient.GetStreamAsync(downloadUrl);
            var result = stream.Result;
            using (var fileStream = System.IO.File.Create(filePath))
            {
                result.CopyTo(fileStream);
            }
