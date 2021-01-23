    int count=0;
    int blocksize = 2205;
    List<List<byte>> blocks =  ARCHIEVE_BUFFER
                                .GroupBy( _ => count++ / blocksize)
                                .Select(x=>x.ToList())
                                .ToList();
            
