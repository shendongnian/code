    using System.IO;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Storage;
    using Windows.Storage.Streams;
    internal static class Extensions
    {
        public static async Task CopyToAsync(this MemoryStream source, StorageFile file)
        {
            using (IRandomAccessStream raStream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (IOutputStream stream = raStream.GetOutputStreamAt(0))
                {
                    await stream.WriteAsync(source.GetWindowsRuntimeBuffer());
                    await stream.FlushAsync();
                }
                raStream.Size = raStream.Position;
            }
        }
    }
