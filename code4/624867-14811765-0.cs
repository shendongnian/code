    FileInfo info = new FileInfo(@"C:\source.bin");
    FileStream f = File.OpenRead(info.FullName);
    BinaryReader br = new BinaryReader(f);
    
    FileStream t = File.OpenWrite(@"C:\split.bin");
    BinaryWriter bw = new BinaryWriter(t);
    
    long count = 0;
    long split = info.Length * 50 / 100;
    long chunk = 8000000;
    
    DateTime start = DateTime.Now;
    
    while (count < split)
    {
    	if (count + chunk > split)
    	{
    		chunk = split - count;
    	}
    
    	bw.Write(br.ReadBytes((int)chunk));
    	count += chunk;
    }
    
    Console.WriteLine(DateTime.Now - start);
