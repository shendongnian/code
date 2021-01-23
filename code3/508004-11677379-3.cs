    public static class Extensions
    {
        public static string ReadLine(this Stream stream, bool returnLineEndBytes = true, byte[] lineEndBytes = null)
        {
            // default end line bytes
            if (lineEndBytes == null)
                lineEndBytes = new byte[2] { 13, 10 };
            StringBuilder stringBuilder = new StringBuilder("");
            var buffer = new byte[lineEndBytes.Length];
            var index = 0;
            do
            {
                var byteRead = stream.ReadByte();
                // end of stream break loop
                if (byteRead == -1)
                    break;
                stringBuilder.Append((char)byteRead);
                buffer[index] = (byte)byteRead;
                if (index == lineEndBytes.Length - 1 && buffer.SequenceEqual(lineEndBytes))
                    break;
                // shift bytes by one to the left
                if (index == lineEndBytes.Length - 1)
                    buffer = buffer.Skip(1).Concat(new byte[] { 0 }).ToArray();
                if (index < lineEndBytes.Length - 1)
                    index++;
            } while (true);
            if (!returnLineEndBytes)
                stringBuilder = stringBuilder.Remove(stringBuilder.Length - lineEndBytes.Length, lineEndBytes.Length);
            return stringBuilder.ToString();
        }
    } 
