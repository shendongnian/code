    private void ProcessAviFiles(){
            if(listToRemove.Count == 0) return; // nothing to do
            lblStatus2.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                                       new Action(() => { lblStatus2.Content = "Convert file to .AVI...";});
                );
             foreach (String file in listToRemove){
                FileInfo fileInfo = new FileInfo(file);
                editpcap = new (classes who convert the files)(fileInfo);
                listBoxFiles.Items.Add(editpcap._newFileName);
             }
             lblStatus2.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                                       new Action(() => { lblStatus2.Content = "AVI file conversion finished...";});
    }
