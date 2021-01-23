    public static async Task<T> ReadObjectFromXmlFileAsync<T>(string filename)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            // this reads XML content from a file ("filename") and returns an object  from the XML
            T objectFromXml = default(T);
            var serializer = new XmlSerializer(typeof(T));
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.GetFileAsync(filename);
            Stream stream = await file.OpenStreamForReadAsync();
            objectFromXml = (T)serializer.Deserialize(stream);
            stream.Dispose();
            timer.Stop();
            double time = timer.ElapsedMilliseconds;
            return objectFromXml;
        }
        public static async Task SaveObjectToXml<T>(T objectToSave, string filename)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            // stores an object in XML format in file called 'filename'
            var serializer = new XmlSerializer(typeof(T));
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            Stream stream = await file.OpenStreamForWriteAsync();
            using (stream)
            {
                serializer.Serialize(stream, objectToSave);
            }
            timer.Stop();
            double time = timer.ElapsedMilliseconds;
            Connection.Downloaded();
        }
    }
