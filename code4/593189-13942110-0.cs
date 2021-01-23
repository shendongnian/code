    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultLabel.Text = "Deleting: " + listView1.SelectedItems[0].Text;
            ResultLabel.Show();
            this.Refresh();
            textBox1.Text = TxtServer.Text + listView1.SelectedItems[0].Text;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(textBox1.Text);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.Credentials = new NetworkCredential(TxtUsername.Text, TxtPassword.Text);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            ResultLabel.Text = "Deleted: " + listView1.SelectedItems[0].Text;
            response.Close();
        }
