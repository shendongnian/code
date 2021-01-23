    Action aviConversion = new Action(() => { 
        if(listToRemove.Count == 0) return; // nothing to do
        lblStatus2.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                                   new Action(() => { lblStatus2.Content = "Convert file to .AVI...";});
            );
         foreach (String file in listToRemove){
            FileInfo fileInfo = new FileInfo(file);
            editpcap = new (classes who convert the files)(fileInfo);
            String newFileName = editpcap._newFileName;
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                                   new Action(() => { 
                                   listBoxFiles.Items.Add(newFileName);
            }));
         }
         lblStatus2.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                                   new Action(() => { lblStatus2.Content = "AVI file conversion finished...";});
    });
    // Run this action in a separate thread...
    Task.Factory.StartNew(action, "beta");
