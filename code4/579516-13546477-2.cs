    void MyForm()
    {
    	_syncContext = SynchronizationContext.Current;
    	Execute(Directory.EnumerateFiles(folderPath, "*.xml").GetEnumerator());
    }
    
    void Execute(IEnumerator<string> files)
    {
    	if (!files.MoveNext())
    	{
    	    files.Dispose();
            return;
    	}
    	Task.Factory.StartNew(() => Execute(files.Current)).ContinueWith(() => Execute(files));
    }
    
    public void Execute(string file)
    {
    	currentReader = new XmlDataReader(transferInstructions, file); //load file
    	currentReader.RowsUploaded += new EventHandler<RowsUploadedEventArgs>(currentReader_RowsUploaded);
    	currentReader.TableUploaded += new EventHandler<TableUploadedEventArgs>(currentReader_TableUploaded);
    	() => currentReader.executeBulkCopy(initialConnString, workingDatabase);
    	cleanUp(task);
    	_syncContext.Send(updateGUI); 
    	transferAction = () => cancelCurrentReader(); 
    }
    public void updateGUI()
    {
    	MessageBox.Show("Complete!");
    	writeResult("Started the transfer process.");
    	cmdDataTransfer.Text = "CANCEL TRANSFER";
    	cmdDataTransfer.ForeColor = Color.DarkRed;
    }
