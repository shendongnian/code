    MemoryStream stream = null;
    MemoryStream streamToDispose = null;
    try
    {
        streamToDispose = stream = new MemoryStream();
        stream.Write(this.GetBinaryRepresentation(), 0, this.GetBinaryRepresentation().Length);
        
        using (WordprocessingDocument document = WordprocessingDocument.Open(stream, true))
        {
            streamToDispose = null;
            OfficeDocument.ModifyDocument(document);
            this.SetBinaryRepresentation(stream.ToArray());
        }
    }
    finally
    {
        if (streamToDispose != null)
        {
            streamToDispose.Dispose();
        }
    }
