    private void button1_Click(object sender, EventArgs e)
    {
        //code from here is moved to BackgroundWorker control
        backgroundWorker1.RunWorkerAsync();
    }
    private void button2_Click(object sender, EventArgs e)
    {
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        //while (true)
        //the condition directly in the while looks more clear to me
        while (vScrollBar1.Value + 1 < vScrollBar1.Maximum)
        {
            //update controls using Invoke method and anonymous functions
            vScrollBar1.Invoke((MethodInvoker)delegate() { vScrollBar1.Value += 1; });
            label1.Invoke((MethodInvoker)delegate() { label1.Text = vScrollBar1.Value.ToString(); });
            //when called inside BackgroundWorker, this sleeps the background thread, 
            //so UI should be responsive now
            System.Threading.Thread.Sleep(200);
        }
    }
