    ISourceBlock<string> FilterLogFile(string fileLocation)
    {
        var block = new BufferBlock<string>();
    
        Task.Run(async () =>
        {
            string line;
    
            using(TextReader file = File.OpenText(fileLocation))
            {        
                while((line = await file.ReadLineAsync()) != null)
                {
                    var match = GetMatch(line);
    
                    if (match != null)
                        block.Post(match);
                }
            }
    
            block.Complete();
        });
    
        return block;
    }
