    public void UploadFileAsync(NameValueCollection values, Stream fileStream)
    {
        //to fire events on the calling thread
        _asyncOperation = AsyncOperationManager.CreateOperation(null);
        var ms = new MemoryStream();
        //make a copy of the input stream in case sb uses disposable stream
        fileStream.CopyTo(ms);
        //you cannot set stream position often enough to zero
        ms.Position = 0;
        Task.Factory.StartNew(() =>
        {
            try
            {
                const string contentType = "application/octet-stream";
                var request = WebRequest.Create(_url);
                request.Method = "POST";
                var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
                request.ContentType = "multipart/form-data; boundary=" + boundary;
                boundary = "--" + boundary;
                var dataStream = new MemoryStream();
                byte[] buffer;
                // Write the values
                foreach (string name in values.Keys)
                {
                    buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                    dataStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.ASCII.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"{1}{1}", name, Environment.NewLine));
                    dataStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.UTF8.GetBytes(values[name] + Environment.NewLine);
                    dataStream.Write(buffer, 0, buffer.Length);
                }
                // Write the file
                buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                dataStream.Write(buffer, 0, buffer.Length);
                buffer = Encoding.UTF8.GetBytes($"Content-Disposition: form-data; name=\"file\"; filename=\"file\"{Environment.NewLine}");
                dataStream.Write(buffer, 0, buffer.Length);
                buffer = Encoding.ASCII.GetBytes(string.Format("Content-Type: {0}{1}{1}", contentType, Environment.NewLine));
                dataStream.Write(buffer, 0, buffer.Length);
                ms.CopyTo(dataStream);
                buffer = Encoding.ASCII.GetBytes(Environment.NewLine);
                dataStream.Write(buffer, 0, buffer.Length);
                buffer = Encoding.ASCII.GetBytes(boundary + "--");
                dataStream.Write(buffer, 0, buffer.Length);
                dataStream.Position = 0;
                //IMPORTANT: set content length to directly write to network socket
                request.ContentLength = dataStream.Length;
                var requestStream = request.GetRequestStream();
                //Write data in chunks and report progress
                var size = dataStream.Length;
                const int chunkSize = 64 * 1024;
                buffer = new byte[chunkSize];
                long bytesSent = 0;
                int readBytes;
                while ((readBytes = dataStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    requestStream.Write(buffer, 0, readBytes);
                    bytesSent += readBytes;
                    var status = "Uploading... " + bytesSent / 1024 + "KB of " + size / 1024 + "KB";
                    var percentage = Tools.Clamp(Convert.ToInt32(100 * bytesSent / size), 0, 100);
                    OnFileUploaderProgressChanged(new FileUploaderProgessChangedEventArgs(status, percentage));
                }
                //get response
                using (var response = request.GetResponse())
                using (var responseStream = response.GetResponseStream())
                using (var stream = new MemoryStream())
                {
                    // ReSharper disable once PossibleNullReferenceException - exception would get catched anyway
                    responseStream.CopyTo(stream);
                    var result = Encoding.Default.GetString(stream.ToArray());
                    OnFileUploaderCompleted(result == string.Empty
                        ? new FileUploaderCompletedEventArgs(FileUploaderCompletedResult.Failed)
                        : new FileUploaderCompletedEventArgs(FileUploaderCompletedResult.Ok));
                }
            }
            catch (Exception)
            {
                OnFileUploaderCompleted(new FileUploaderCompletedEventArgs(FileUploaderCompletedResult.Failed));
            }
        }, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
    }
