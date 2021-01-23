            HttpClient httpClient = new HttpClient();
            var documentList=_documentManager.GetAllDocuments();
            documentList.AsParallel().ForAll(doc =>
            {
                var responseResult= httpClient.GetAsync(doc.FileURLPath);
                using (var memStream = responseResult.Result.Content.ReadAsStreamAsync().Result)
                {
                    using (var fileStream =File.Create($"{filePath}\\{doc.FileName}"))
                    {
                        memStream.CopyTo(fileStream);
                    }
                }
            });
