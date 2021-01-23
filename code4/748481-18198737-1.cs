    public static void Deserialize<T>(ObservableCollection<T> list , string filename)
        {
            list = new ObservableCollection<T>();
            var userStore = IsolatedStorageFile.GetUserStoreForApplication();
            if (userStore.FileExists(filename))
            {
                using (var stream = new IsolatedStorageFileStream(filename, FileMode.Open, userStore))
                {
                    XmlSerializer serializer = new XmlSerializer(list.GetType());
                    var items = (ObservableCollection<T>)serializer.Deserialize(stream);
                    foreach (T item in items)
                    {
                        list.Add(item);
                    }
                }
            }
        }
