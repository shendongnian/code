    private async Task SaveData()
    {
        if (GetActiveServiceRequest() != null)
        {
            var tokenSource = new System.Threading.CancellationTokenSource(TimeSpan.FromSeconds(5));
            var token = tokenSource.Token;
            this.ShowWizardPleaseWait("Saving data...");
            var someTask = System.Threading.Tasks.Task.Run(() =>
            {
                // Set sleep of 7 seconds to test the 5 seconds timeout.
                System.Threading.Thread.Sleep(7000);
                // if not cancelled then save data
                token.ThrowIfCancellationRequested();
                using (App.Data.EmployeeWCF ws = new App.Data.EmployeeWCF())
                {
                    return ws.UpdateData(_employee.Data);
                }
            }, token);
            try
            {
                var result = await someTask;
                // Completed
                this.HideWizardPleaseWait();
                if (result)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                }
                btnOK.Enabled = true;
                this.Close();
            }
            catch (OperationCanceledException)
            {
                // Timeout logic
                this.HideWizardPleaseWait();
                MessageBox.Show("Timeout. Please try again.")
            }
        }
    }
