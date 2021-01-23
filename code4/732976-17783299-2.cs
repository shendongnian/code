       public class CacheData {
            private object row;
            public CacheData(object row)
            {
                //initialization
            }
            public static ProcessedData ProcessData(List<CacheData> dataToProcess)
            {
                return new ProcessedData();
            }
        }
        public class ProcessedData { }
        private void AccessControl()
        {
            ListView list = new ListView();
            List<CacheData> cache = new List<CacheData>();
            //Filling the cache on UI
            foreach (var row in list.Items)
            {
                cache.Add(new CacheData(row));
            }
            //Process result async and then invoke on UI back
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
            bg.DoWork += (sender,e) => {
                e.Result = CacheData.ProcessData(cache);
            };
            bg.RunWorkerCompleted += (sender, e) => { 
            
                //If you have started your bg from UI result will be invoked in UI automatically. 
                //Otherwise you should invoke it manually.
                list.Dispatcher.Invoke((Action) delegate {
                    //pass e.result to control here)
                },null);
            };
            bg.RunWorkerAsync();
            
        }
