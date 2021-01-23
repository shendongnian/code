    MemoryStream stream = null;
    try
    {
        stream = new MemoryStream();
        stream.Write(this.GetBinaryRepresentation(), 0, this.GetBinaryRepresentation().Length);
        byte[] binaryRepresentation = stream.ToArray();
        using (WordprocessingDocument document = WordprocessingDocument.Open(stream, true))
        {
            stream = null;
            OfficeDocument.ModifyDocument(document);
            this.SetBinaryRepresentation(binaryRepresentation);
        }
    }
    finally
    {
        if (stream != null)
        {
            stream.Dispose();
        }
    }
