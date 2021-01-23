    private void btnAddfiles_Click(object sender, EventArgs e)
    {
        System.IO.Stream stream;
        OpenFileDialog thisDialog = new OpenFileDialog();
        thisDialog.InitialDirectory = (lastPath.Length > 0 ? lastPath : "c:\\");
        thisDialog.Filter = "(*.snoop, *.pcap, *.cap, *.net, *.pcapng, *.5vw, *.bfr, *.erf, *.tr1)" +
            "|*.snoop; *.pcap; *.cap; *.net; *.pcapng; *.5vw; *.bfr; *.erf; *.tr1|" + "All files (*.*)|*.*";
        thisDialog.FilterIndex = 1;
        thisDialog.RestoreDirectory = false;
        thisDialog.Multiselect = true;
        thisDialog.Title = "Please Select Source File";
    
        if (thisDialog.ShowDialog() == DialogResult.OK)
        {
            if (thisDialog.FileNames.Length > 0)
            {
                lastPath = Path.GetDirectoryName(thisDialog.FileNames[0]);
            }
    
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork +=
            (s3, e3) =>
            {
                //TODO consider moving everything inside of the `DoWork` handler to another method
                //it's a bit long for an anonymous method
                foreach (String file in thisDialog.FileNames)
                {
                    try
                    {
                        if ((stream = thisDialog.OpenFile()) != null)
                        {
                            using (stream)
                            {
                                Editcap editcap = new Editcap();
                                if (!editcap.isLibpcapFormat(file))
                                {
                                    string fileToAdd = editcap.getNewFileName(file);
                                    backgroundWorker.ReportProgress(0, fileToAdd);
                                }
                                else
                                {
                                    backgroundWorker.ReportProgress(0, file);
                                }
    
    
                                lastPath = Path.GetDirectoryName(thisDialog.FileNames[0]);
                            }
                        }
                    }
    
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            };
    
            backgroundWorker.ProgressChanged +=
                (s3, arguments) =>
                {
                    listBoxFiles.Items.Add(arguments.UserState);
                };
    
            backgroundWorker.RunWorkerAsync();
    
        }
    }
