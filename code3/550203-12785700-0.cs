    OpenFileDialog dialog = new OpenFileDialog();
                bool? retVal = dialog.ShowDialog();
                if (retVal.HasValue && retVal == true)
                {
                    using (Stream stream = dialog.File.OpenRead())
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        stream.CopyTo(memoryStream);
                        WebClient webClient = new WebClient();
                        webClient.Headers["Content-type"] = "multipart/form-data; boundary=---------------------------" + _boundaryNo;
                        webClient.OpenWriteAsync(new Uri("http://localhost:1463/Home/File", UriKind.Absolute), "POST", new { Stream = memoryStream, FileName = dialog.File.Name });
                        webClient.OpenWriteCompleted += new OpenWriteCompletedEventHandler(webClient_OpenWriteCompleted);
                    }
                } 
