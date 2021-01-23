    private static void Append(string xmlElement)
    {
        const byte lessThan = (byte) '<';
        using (FileStream stream = File.Open(@"C:\log.xml", FileMode.OpenOrCreate))
        {
            if (stream.Length == 0)
            {
                byte[] rootElement = Encoding.UTF8.GetBytes("<Logs></Logs>");
                stream.Write(rootElement, 0, rootElement.Length);
            }
            List<byte> buffer = new List<byte>();
            stream.Seek(0, SeekOrigin.End);
            do
            {
                stream.Seek(-1, SeekOrigin.Current);
                buffer.Insert(0, (byte) stream.ReadByte());
                stream.Seek(-1, SeekOrigin.Current);
            } while (buffer[0] != lessThan);
            byte[] toAdd = Encoding.UTF8.GetBytes(xmlElement);
            stream.Write(toAdd, 0, toAdd.Length);
            stream.Write(buffer.ToArray(), 0, buffer.Count);
        }
    }
