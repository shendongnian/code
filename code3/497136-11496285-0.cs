    private byte[] RemoveHashBlocks(byte[] fileArray, STFSExplorer stfs)
    {
        long startOffset = StartingOffset;
        long size = Size;
    
        MemoryStream ms = new MemoryStream();
        long lastBlockEnd = 0;
    
        foreach (xBlockEntry block in stfs._stfsBlockEntry)
        {
            if (block.IsHashBlock)
            {
                long offset = block.BlockOffset - startOffset;
                if (offset + 0x1000 > 0 && offset < size)
                {
                    if (offset > lastBlockEnd)
                    {
                        ms.Write(fileArray, (int) lastBlockEnd,
                                (int) (offset - lastBlockEnd));
                    }
                    lastBlockEnd = offset + 0x1000;
                }
            }
        }
    
        if (lastBlockEnd < size)
        {
            ms.Write(fileArray, (int) lastBlockEnd, (int) (size - lastBlockEnd));
        }
    
        return ms.ToArray();
    }
