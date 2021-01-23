            request.BeginGetRequestStream((requestResult =>
            {
                using (StreamWriter streamWriter = new StreamWriter(request.EndGetRequestStream(requestResult)))
                {
                    streamWriter.WriteLine(boundary);
                    streamWriter.WriteLine("Content-Disposition: form-data; name=\"json\"");
                    streamWriter.WriteLine("Content-Type: text/plain; charset=utf-8");
                    streamWriter.WriteLine("Content-Transfer-Encoding: 8bit");
                    streamWriter.WriteLine(json);
                    streamWriter.WriteLine(boundary);
                    streamWriter.WriteLine("Content-Disposition: form-data; name=\"image\"; filename=\"image.jpg\"");
                    streamWriter.WriteLine("Content-Type: application/octet-stream");
                    streamWriter.WriteLine("Content-Transfer-Encoding: binary");
                    streamWriter.WriteLine("");
                    streamWriter.Flush();
                    streamWriter.CopyTo(stream.BaseStream);
                    streamWriter.WriteLine("");
                    streamWriter.WriteLine(boundary);
                    streamWriter.Close();
                }
                ExecuteRequest(this, request);
            }), request);
