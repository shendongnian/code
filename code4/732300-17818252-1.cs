    public class Settings
    {
        private const string FileName = "shared/settings.json";
        private Settings() { }
        public bool Foo { get; set; }
        public int Bar { get; set; }
        public static Settings Load()
        {
            var storage = IsolatedStorageFile.GetUserStoreForApplication();
            if (storage.FileExists(FileName) == false) return new Settings();
            using (var stream = storage.OpenFile(FileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    if (string.IsNullOrEmpty(json) == false)
                    {
                        return JsonConvert.DeserializeObject<Settings>(json);
                    }
                }
            }
            return new Settings();
        }
        public void Save()
        {
            var storage = IsolatedStorageFile.GetUserStoreForApplication();
            if(storage.FileExists(FileName)) storage.DeleteFile(FileName);
            using (var fileStream = storage.CreateFile(FileName))
            {
                //Write the data
                using (var isoFileWriter = new StreamWriter(fileStream))
                {
                    var json = JsonConvert.SerializeObject(this);
                    isoFileWriter.WriteLine(json);
                }
            }
        }
    }
