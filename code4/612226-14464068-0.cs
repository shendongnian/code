    public static class Ext
    {        
        public static IObservable<byte[]> ReadObservable(this Stream stream, int bufferSize)
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
