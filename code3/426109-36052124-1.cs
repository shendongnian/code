        int interlockCount=0;
        private async void button1_Click(object sender, EventArgs e)
        {
            if (Interlocked.CompareExchange(ref interlockCount, 1,0) == 0)
            {
                int t = await Task.Run(() => getVal());
                textBox1.Text = t.ToString();
                Interlocked.Exchange(ref interlockCount, 0);
            }
        }
