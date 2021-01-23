    void Main()
    {    
        // Our fake network stream file
        var filePath = @"c:\temp\simulatedNetworkData.bin";
        // we'll use this to check our work
        var allBytes = File.ReadAllBytes(filePath);
        
        using(var fs = File.OpenRead(filePath))
        {
            // buffer in 1k chunks
            var obs = fs.ReadObservable(1024);        
                
            // ToEnumerable basically pulls from the 
            // IObservable until it's "done" - BE CAREFUL,
            // don't do this with "potentially infinite" observables
            var compareBuffer = obs
                .TakeWhile(returnBuffer => returnBuffer.Length > 0)
                .ToEnumerable()
                .SelectMany (returnBuffer => returnBuffer)
                .ToArray();
                
            Console.WriteLine(
                "Observed buffer == known buffer? {0}", 
                // overly fancy way of saying "these two sequences equal?"
                allBytes
                    .Zip(compareBuffer, 
                        (a,b) => new { Known = a, Test = b})
                    .All(t => t.Known == t.Test));
        }
    }
    
    
    public static class Ext
    {        
        public static IObservable<byte[]> ReadObservable(
             this Stream stream, 
             int bufferSize)
        {        
            // to hold read data
            var buffer = new byte[bufferSize];
            // Step 1: async signature => observable factory
            var asyncRead = Observable.FromAsyncPattern<byte[], int, int, int>(
                stream.BeginRead, 
                stream.EndRead);
            return Observable.While(
                // while there is data to be read
                () => stream.CanRead, 
                // iteratively invoke the observable factory, which will
                // "recreate" it such that it will start from the current
                // stream position - hence "0" for offset
                Observable.Defer(() => asyncRead(buffer, 0, bufferSize))
                    .Select(readBytes => buffer.Take(readBytes).ToArray()));
        }
    }
