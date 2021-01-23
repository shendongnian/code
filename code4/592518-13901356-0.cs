    class Resource
    {
        private static readonly string ResourcePath = AppDomain.CurrentDomain.BaseDirectory + "resources.pak";
        private const string ResourcePassword = "0ORzjHcFxV0QXTuOizu0";
        private static ZipFile Read(string filepath, string password = null)
        {
            var file = ZipFile.Read(filepath);
            file.Password = password;
            return file;
        }
        internal static List<string> GetFiles(string haystack, string needle = "*")
        {
            var resource = Read(ResourcePath, ResourcePassword).SelectEntries(needle, haystack);
            return resource.Select(filepath => filepath.ToString().Replace("ZipEntry::", "")).ToList();
        }
        internal static Task<MemoryStream> ReadFile(string filepath)
        {
            return Task.Run(() =>
                {
                    var file = Read(ResourcePath, ResourcePassword);
                    var stream = new MemoryStream();
                    file[filepath].Extract(stream);
                    return stream;
                });
        }
        internal async static Task<ImageSource> StreamImage(string filepath)
        {
            var imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.StreamSource = await ReadFile(filepath);
            imageSource.EndInit();
            return imageSource;
        }
        internal async static Task<int[]> ImageSize(string filepath)
        {
            int[] sizeValues = { 0, 0 };
            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = await ReadFile(filepath);
            image.EndInit();
            sizeValues[0] = image.PixelWidth;
            sizeValues[1] = image.PixelHeight;
            return sizeValues;
        }
    }
