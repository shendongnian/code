        object lock_obj = new object();
        private async void button1_Click(object sender, EventArgs e)
        {
            if (Monitor.TryEnter(lock_obj))
            {
                int t = await Task.Run(() => getVal());
                textBox1.Text = t.ToString(); ;
                Monitor.Exit(lock_obj);
            }
        }
        int count = 0;
        int getVal()
        {
        Thread.Sleep(1000);
        count++;
        return count;
        }
