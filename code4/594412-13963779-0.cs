    IDisposable _disposable; 
    private void btnAddDir_Click_1(object sender, EventArgs e)
    {
        string fileToAdd = string.Empty;
        DialogResult dialog = folderBrowserDialog1.ShowDialog();
        if (dialog == DialogResult.OK)
        {
            Editcap editcap = new Editcap();
            var observable = SafeFileEnumerator.EnumerateFiles(folderBrowserDialog1.SelectedPath, "*.*", SearchOption.AllDirectories)
                .ToObservable()
                .SubscribeOn(NewThreadScheduler.Default);
            _disposable = observable.Subscribe((fileName) =>
                {
                    if (editcap.isWiresharkFormat(fileName))
                    {
                        if (editcap.isLibpcapFormat(fileName))
                        {
                            listBoxFiles.Items.Add(fileName);
                        }
                        else if (!editcap.isLibpcapFormat(fileName))
                        {
                            listBoxFiles.Items.Add(editcap.getNewFileName(fileName));
                        }
                    }
                });
        }
    }
