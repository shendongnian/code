    using ( var mmf = MemoryMappedFile.CreateFromFile( path ) )
    {    
        for ( long offset = 0 ; offset < file.Size ; offset += block_size )
        {
            using ( var acc = accessor = mmf.CreateViewAccessor(offset, 1) )
            {
                acc.ReadByte(offset);
            }
        }
    }
