    public class MyXmlDataProvider : XmlDataProvider
        {
            public new Uri Source
            {
                get { return base.Source; }
                set
                {
                    base.Source = value;
     
                    FileSystemWatcher watcher = new FileSystemWatcher();
                    //set the path of the XML file appropriately as per your requirements
                    watcher.Path = AppDomain.CurrentDomain.BaseDirectory;
     
                    //name of the file i am watching
                    watcher.Filter = value.OriginalString;
     
                    //watch for file changed events so that we can refresh the data provider
                    watcher.Changed += new FileSystemEventHandler(file_Changed);
     
                    //finally, don't forget to enable watching, else the events won't fire           
                    watcher.EnableRaisingEvents = true;
                }
            }
     
            void file_Changed(object sender, FileSystemEventArgs e)
            {
                base.Refresh();
            }
        }
