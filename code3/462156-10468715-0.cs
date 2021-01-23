        public void Search(string path, string name)
        {
            Thread th = new Thread(s => SearchThread(path, name));
            th.Start();
        }
        private void SearchThread(string path, string name)
        {
            try
            {
                _Search(path, name);
            }
            finally
            {
                callback.SearchEnd();
                if (stopSearch)
                {
                    callback.InfoLabel("Search Cancelled", InfoState.Info);
                    stopSearch = false;
                }
                else
                    callback.InfoLabel("Search Done.", InfoState.Done);
            }
        }
