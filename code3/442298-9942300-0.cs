        void fun1(DownloadStringCompletedEventArgs e) { Process(e.Result); }
        void fun2(UploadStringCompletedEventArgs e) { Process(e.Result); }
        private void Process(string result)
        {
            try
            {
                string s = result;
            }
            catch (WebException eX)
            {
                HandleWebException();
            }
        }
