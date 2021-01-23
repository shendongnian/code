        public static void Copy(Stream input, Stream output, long length)
        {
            byte[] bytes = new byte[65536];
            long bytesRead = 0;
            int len = 0;
            while (0 != (len = input.Read(bytes, 0, Math.Min(bytes.Length, (int)Math.Min(int.MaxValue, length - bytesRead)))))
            {
                output.Write(bytes, 0, len);
                bytesRead = bytesRead + len;
            }
            output.Flush();
            if (bytesRead != length)
                throw new IOException();
        }
