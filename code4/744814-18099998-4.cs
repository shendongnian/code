    List<object> _queue = new List<object>();
    bool _paused = false;
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        string StrMSGdata = "";
        string tStamp = "";
        for (int i = 0; i < 100; i++)
        {
            StrMSGdata = i.ToString();
            tStamp = DateTime.Now.ToLongTimeString();
            backgroundWorker1.ReportProgress(i, StrMSGdata + "#" + tStamp);
            Thread.Sleep(1000);
        }
    }
    private void backgroundWorker1_ProgressChanged(
        object sender, ProgressChangedEventArgs e)
    {
        string recived = e.UserState.ToString();
        string[] fullMsgData = new string[15];
        fullMsgData = recived.Split('#');
        string msgData = fullMsgData[0];
        string timStamp = fullMsgData[1];
        if (_paused)
        {
            _queue.Add(new[]{ timStamp, msgData });
        }
        else
        {
            dataGridView1.Rows.Add(timStamp, msgData);
        }
    }
    private void pauseButton_Click(object sender, EventArgs e)
    {
        _paused = !_paused;
        pauseButton.Text = (_paused) ? "Start" : "Pause";
        if (!_paused)
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate()
                {
                    _queue.ForEach(item =>
                    {
                        dataGridView1.Rows.Add(item);
                    });
                    _queue.Clear();
                }));
            }
            else
            {
                _queue.ForEach(item =>
                {
                    dataGridView1.Rows.Add((string[])item);
                });
                _queue.Clear();
            }
    }
