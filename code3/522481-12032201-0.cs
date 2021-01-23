    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                progressBar1.Value = e.ProgressPercentage;
                progressBar1.Refresh();
    
                listBox1.Items.Add( "Converting File: " + e.UserState.ToString());
                textBox1.Text = e.ProgressPercentage.ToString();
            }
