    BackgroundWorker bw = new BackgroundWorker();
    public void Form_Load(Object sender, EventArgs e) {
        // Show the loading label before we start working...
        loadingLabel.Show();
        bw.DoWork += (s, e) => {
           // Do your checks here
        }
        bw.RunWorkerCompleted += (s, e) => { 
           // Hide the loading label when we are done...
           this.Invoke(new Action(() => { loadingLabel.Visible = false; })); 
        };
        bw.RunWorkerAsync();
    }
