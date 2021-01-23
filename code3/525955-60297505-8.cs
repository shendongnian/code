    var progressDialog = new ProgressDialog();
    progressDialog.Progressbar.Value = 0;
    progressDialog.Progressbar.Maximum = 100;
    
    progressDialog.RunAsync(() =>
    {
        for (int i = 0; i < 100; i++)
        {
            Thread.Sleep(1000)
            this.progressDialog.Progressbar.BeginInvoke((MethodInvoker)(() => {
                this.progressDialog.Progressbar.Value += 1;
            }));
        }
    });
    
    progressDialog.ShowDialog();
