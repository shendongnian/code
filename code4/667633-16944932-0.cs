     try
            {
                using (
                var client = new HttpClient())
                using (var form = new MultipartFormDataContent())
                {
                    using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                        using (var fileContent = new StreamContent(stream)) {
    
                            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") {FileName = fileName, DispositionType = DispositionTypeNames.Attachment, Name = "fileData"};
    
                            form.Add(fileContent);
                            // only for test purposes, for stable environment, use ApiRequest class.
                            response = client.PostAsync(url, form).Result;
                        }
                    }
                }
    
                return response.RequestMessage != null ? response.ReasonPhrase : null;
            }
            catch (Exception ex)
            {
                TraceManager.TraceError("Post Asyn Request to " + url + " \n" + ex.Message, ex);
                throw;
            }
