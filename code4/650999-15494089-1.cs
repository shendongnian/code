    private void Application_Closing(object sender, ClosingEventArgs e)
    {
        ViewModel.ClearUnnecessaryData();
        using (var store = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (var stream = new IsolatedStorageFileStream("data.txt", FileMode.Create, FileAccess.Write, store))
            {
                var serializer = new XmlSerializer(typeof(AppViewModel.NewsViewModel));
                serializer.Serialize(stream, ViewModel);
            }
        }
    }
