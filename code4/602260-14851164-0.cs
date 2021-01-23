    public static class HttpWorkerRequestExtension
    {
        public static int ReadEntityBodyEx(this HttpWorkerRequest request, byte[] buffer, int offset, int size)
        {
            int bytesRead = 0;
            int totalBytesRead = 0;
            int bytesToRead = size;
            while (bytesToRead > 0)
            {
                bytesRead = request.ReadEntityBody(buffer, offset + totalBytesRead, size - totalBytesRead);
                if (bytesRead == 0) { break; }
                bytesToRead -= bytesRead;
                totalBytesRead += bytesRead;
            }
            return totalBytesRead;
        }
        public static int ReadEntityBodyEx(this HttpWorkerRequest request, byte[] buffer, int size)
        {
            return request.ReadEntityBodyEx(buffer, 0, size);
        }
    }
