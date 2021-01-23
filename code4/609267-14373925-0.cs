    void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        _timer.Stop();
        lock (_locker)
        {
            this.Invoke((MethodInvoker)delegate
        {
            if (listBox2.SelectedIndex + 1 < listBox2.Items.Count)
            {
                listBox2.SelectedItem = listBox2.Items[listBox2.SelectedIndex + 1];
                //now play the file ? what is the problem ?
            }
        });
        }
    }
