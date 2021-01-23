    public class CacheImageFileConverter : IValueConverter
    {
        ...
        private static ManualResetEvent mre = new ManualResetEvent(true);
        private static object DownloadFromWeb(Uri imageFileUri)
        {
            mre.Reset();
            WebClient m_webClient = new WebClient();                                //Load from internet
            BitmapImage bm = new BitmapImage();
            m_webClient.OpenReadCompleted += (o, e) =>
            {
                if (e.Error != null || e.Cancelled) return;
                WriteToIsolatedStorage(IsolatedStorageFile.GetUserStoreForApplication(), e.Result, GetFileNameInIsolatedStorage(imageFileUri));
                bm.SetSource(e.Result);
                e.Result.Close();
                mre.Set();
            };
            m_webClient.OpenReadAsync(imageFileUri);
            return bm;
        }
        private static object ExtractFromLocalStorage(Uri imageFileUri)
        {
            mre.WaitOne();
            string isolatedStoragePath = GetFileNameInIsolatedStorage(imageFileUri);       //Load from local storage
            using (var sourceFile = _storage.OpenFile(isolatedStoragePath, FileMode.Open, FileAccess.Read))
            {
                BitmapImage bm = new BitmapImage();
                bm.SetSource(sourceFile);
                return bm;
            }
        }
        .... other methods
    }
