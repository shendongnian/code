    private void backgroundWorker1_RunWorkerCompleted(object sender,
    RunWorkerCompletedEventArgs e)
    {
    // newline is unnecesary and you should be using foreach
      foreach(FileSystemInfo f in fsi)
      {                
        listBox1.Items.Add(f);
      }
    }
    // display full name of file
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      label2.Text = ((FileSystemInfo)listBox1.SelectedItem).Fullname;
    }         
