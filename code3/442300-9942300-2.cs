        void fun1(DownloadStringCompletedEventArgs e) { Process(e); }
        void fun2(UploadStringCompletedEventArgs e) { Process(e); }
        private void Process(dynamic eventArgs)
        {
            try
            {
                string s = eventArgs.Result;
            }
            catch (WebException e)
            {
                HandleWebException(e);
            }
        }
