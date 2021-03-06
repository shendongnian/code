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
            //Filling the cache in UI
            foreach (var row in list.Items)
            {
                cache.Add(new CacheData(row));
            }
            //Process result async and then invoke in UI back
            System.ComponentModel.BackgroundWorker bg = new System.ComponentModel.BackgroundWorker();
            bg.DoWork += (sender,e) => {
                e.Result = CacheData.ProcessData(cache);
            };
            bg.RunWorkerCompleted += (sender, e) => { 
            
                //invoke result in UI
                list.Dispatcher.Invoke((Action) delegate {
                    //pass e.result to control here)
                },null);
            };
            bg.RunWorkerAsync();
            
        }
