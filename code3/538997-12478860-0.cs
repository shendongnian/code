    private void setDebug(string value)
    {
        debug.Text = value;
    }
    
    private void buildButton_Click(object sender, EventArgs e)
    {
        BackgroundWorker worker = new BackgroundWorker();
        string java_folder = @"C:\Program Files\Java";
        if (Directory.Exists(java_folder))
        {
            setDebug("Deleting Java folder...");
            worker.DoWork += (sender, args) => // this is the off-thread code
            {
                // delete java folder
                Directory.Delete(java_folder, true);
            };
            worker.RunWorkerCompleted += (sender,args)=>  // this goes off when .DoWork is done
            {
                progressBar.Value += 10; 
            };
            
            // this invokes .DoWork handler (which we defined above)
            worker.RunWorkerAsync();
        }
    }
