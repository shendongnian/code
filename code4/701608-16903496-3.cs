        public static async Task<string> ReadLineAsync(this Stream stream, Encoding encoding)
        {
            const int count = 2;
            byte[] byteArray = Enumerable.Empty<byte>().ToArray();
            using (MemoryStream ms = new MemoryStream())
            {
                int bytesRead = 0;
                do
                {
                    byte[] buf = new byte[count];
                    try
                    {
                        bytesRead = await stream.ReadAsync(buf, 0, count);
                        await ms.WriteAsync(buf, 0, bytesRead);
                        Console.WriteLine("{0:ffffff}:{1}:{2}",DateTime.Now, stream.CanRead, bytesRead);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message + e.StackTrace);
                    }
                } while (stream.CanRead && bytesRead > 0);
                byteArray = ms.ToArray();
                return encoding.GetString(byteArray);
            }
        }
