    public static void Main()
    {
        // Wrap all of the work that needs to be done in a closure.
        // This represents all the work that needs to be done while the stream is open.
        Func<Stream, String> streamClosure = delegate(Stream stream) {
            using (StreamReader streamReader = new StreamReader(stream)) {
                return streamReader.ReadToEnd();
            }
        };
        // Call StreamWork. This method handles creating/closing the stream.
        String result = StreamWork(streamClosure);
        Console.WriteLine(result);
        Console.ReadLine();
    }
