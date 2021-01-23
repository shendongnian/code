    public bool FindAppendPoint(Stream stream)
    {
        XmlTextReader xr = new XmlTextReader(stream);
        string rootElement = null;
        while (xr.Read())
        {
            if (xr.NodeType == XmlNodeType.Element)
            {
                rootElement = xr.Name;
                break;
            }
        }
        if (rootElement == null)
        {
            // Well, apparently there's no root... You can start a new file I suppose
            return false;
        }
        else
        {
            long start = stream.Position; // the position we're currently reading (end of start tag)
            long len = stream.Length;
            long end = Math.Min(start, len - 1024);
            byte[] endTag = xr.Encoding.GetBytes("</" + rootElement);
            while (end >= start)
            {
                byte[] data = new byte[len - end];
                stream.Seek(start, SeekOrigin.Begin);
                stream.Read(data, 0, data.Length); // FIXME: read returns an int that we should use!!!
                // Loop backwards till we find the end tag
                for (int i = data.Length - endTag.Length; i >= 0; --i)
                {
                    int j;
                    for (j = 0; j < endTag.Length && endTag[j] == data[i + j]; ++j) { }
                    if (j == endTag.Length)
                    {
                        // We found a match!
                        stream.Seek(len - data.Length - i, SeekOrigin.Begin);
                        AppendXml(stream, xr.Encoding)
                        return true;
                    }
                }
                // Hmm, we've found </xml with a lot of spaces... oh well
                //
                // It's okay to skip back a bit, just have to make sure that we don't skip <0
                if (end == start)
                {
                    end = start - 1; // end the loop
                }
                else
                {
                    end = Math.Min(start, end - 1024);
                }
            }
            // Nope, no go.
            return false;
        }
    }
