    YourType arrayitem;
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        TcpClient client = new TcpClient();
        client.Connect("192.168.1.3", 10);
        StreamWriter writer = new StreamWriter(client.GetStream());
        StreamReader reader = new StreamReader(client.GetStream());
        JObject o = new JObject();
        o.Add("comando", 1);
        o.Add("dir", @"C:\Users\klein\Desktop\Acionamentos");
        writer.Write(o.ToString());
        writer.Flush();
        JArray array = JArray.Parse(reader.ReadToEnd());
				
        int percentage;
				
        for (int i = 0; i < array.Count; i++)
        {
            arrayitem = array[i];
            percentage = ((i + 1)*100)/array.Count;
            backgroundWorker1.ReportProgress(percentage);
        }
    }
		
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        listBox1.Items.Add(arrayitem);
        progressBar1.Value = e.ProgressPercentage; // in case you'd want to add a progressbar
    }
		
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        label1.Text = "Done";
    }
