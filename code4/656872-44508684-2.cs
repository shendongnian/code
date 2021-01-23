    async Task Main()
    {
	    var list = new List<Task<Stream>> { GetStreamFromStringAsync("Hello"), GetStreamFromStringAsync(" World") };
   	    Stream stream = await list
				.Select(async item => await item)
				.Aggregate((current, next) => Task.FromResult(current.Result.Append(next.Result)));
	
    	Console.WriteLine(Encoding.UTF8.GetString((stream as MemoryStream).ToArray()));
    }
    public static Task<Stream> GetStreamFromStringAsync(string text)
    {
	    MemoryStream stream = new MemoryStream();
    	StreamWriter writer = new StreamWriter(stream);
    	writer.Write(text);
    	writer.Flush();
	    stream.Position = 0;
    	return Task.FromResult(stream as Stream);
    }
    public static class Extensions
    {
	    public static Stream Append(this Stream destination, Stream source)
    	{
	    	destination.Position = destination.Length;
		    source.CopyTo(destination);
    		return destination;
	    }
    }
