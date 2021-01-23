    void button1_Click(object sender, EventArgs e) {
        button1.Enabled = false;
        BeginAsyncOperation(updateUI);
    }
    void BeginAsyncOperation(Action operation) {
        operation.BeginInvoke(OnAsyncCallback, null);
    }
    void OnAsyncCallback(IAsyncResult result) {
        if(result.IsCompleted) {
            if(!InvokeRequired)
                callback();
            else BeginInvoke(new Action(callback));
        }
    }
    //
    public void callback() {
        button1.Enabled = true;
        // something else
    }
    public void updateUI() {
        // long function....doing 10s
        System.Threading.Thread.Sleep(10000);
    }
