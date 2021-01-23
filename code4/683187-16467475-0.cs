    using System.Runtime.InteropServices.WindowsRuntime;
    internal static async Task<InMemoryRandomAccessStream> ConvertTo(byte[] arr)
    {
        InMemoryRandomAccessStream randomAccessStream = new InMemoryRandomAccessStream();
        await randomAccessStream.WriteAsync(arr.AsBuffer());
        stream.Seek(0); // Just to be sure.
                        // I don't think you need to flush here, but if it doesn't work, give it a try.
        return randomAccessStream;
    }
