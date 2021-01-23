        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            string path = (string)e.Argument;
            processFile(path);
        }
        private void processToolStripMenuItem_Click(object sender, EventArgs e) {
            backgroundWorker1.RunWorkerAsync(openSingleFile.FileName);
            processToolStripMenuItem.Enabled = false;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            processToolStripMenuItem.Enabled = true;
        }
