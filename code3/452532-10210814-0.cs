    private void writer(Stream stream)
        {
            using (FileStream reader = File.OpenRead("d:\\download\\largefile.iso"))
            {
                byte[] buffer = new byte[16384]; //16k buffer
                int bytesRead = 0;
                int read = 0;
                while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, read);
                    stream.Flush();
                    bytesRead += read;
                    System.Diagnostics.Debug.WriteLine("uploading: " + (int)((double)bytesRead / reader.Length * 100) + "%");
                }
                reader.Close();
            }
        }
