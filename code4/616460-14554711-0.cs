        private static FileSystemWatcher deliverycompletewatcher;
        public static void watchxmlfile(string batchfolderpath)
        {
            deliverycompletewatcher = new FileSystemWatcher();
            deliverycompletewatcher.Path = batchfolderpath;
            deliverycompletewatcher.Filter = "*.xml";
            deliverycompletewatcher.Created += OnChanged;
            deliverycompletewatcher.EnableRaisingEvents = true;
        }
        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            deliverycompletewatcher.EnableRaisingEvents = false;
            deliverycompletewatcher.Created -= OnChanged;
            
            // Do some cool stuff
        }
