       var memoryMapName = Path.GetFileName(fileToRead);
    using (var mapStream = new FileStream(fileToRead, FileMode.Open))
    {
        using (MemoryMappedFile myMap = MemoryMappedFile.CreateFromFile(mapStream, 
                                memoryMapName, mapStream.Length,
                                MemoryMappedFileAccess.Read, null, 
                                HandleInheritability.None, false))
        {                    
            long leftToRead = mapStream.Length;
            long mapSize = Math.Min(1024 * 1024, mapStream.Length);
            long bytesRead = 0;
            long mapOffset = Math.Max(mapStream.Length - mapSize, 0);
                       
            while (leftToRead > 1)
            {
                using (MemoryMappedViewAccessor FileMap = myMap.CreateViewAccessor(mapOffset, 
                                                mapSize, MemoryMappedFileAccess.Read))
                {
                    long readAt = mapSize - 2;
                    while (readAt > -1)
                    {
                        var int16Read = FileMap.ReadInt16(readAt);
                        //0xEB25  <--check int16Read here                            
                        bytesRead += 1;
                        readAt -= 1;
                    }
                }
    
                leftToRead = mapStream.Length- bytesRead;
                mapOffset = Math.Max(mapOffset - mapSize, 0);
                mapSize = Math.Min(mapSize, leftToRead);
            }
        }
    }
