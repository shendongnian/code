    private void BwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                // First, handle the case where an exception was thrown.
                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message);
                }
    
               // 
                if (e.Result != null)
                {
                    // test if result is true or false <== HERE YOU GO!
                    if ((Boolean)e.Result == true)
                    {
                        this.Hide();
                        Form fm = new SFGrilla(ref lr, ref binding);
                        fm.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    // hide the progress bar when the long running process finishes
                    progressBar.Visible = false;
    
                    // enable button
                    btnLogin.Enabled = true;
                }
    
            }
    
