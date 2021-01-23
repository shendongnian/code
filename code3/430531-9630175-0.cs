    private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (backgroundWorker1.IsBusy) {
                MessageBox.Show("Thread busy!");
                e.Cancel = true;
            }
        }
