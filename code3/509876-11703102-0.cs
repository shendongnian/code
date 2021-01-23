    private void button1_Click(object sender, EventArgs e)
        {
            if (thread2!=null && thread2.IsAlive)
            {
                thread2.Abort();
            }
            thread1 = new Thread(threadOne);
            thread1.Start();
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            if (thread1!=null && thread1.IsAlive)
            {
                thread1.Abort();
            }
            thread2 = new Thread(threadTwo);
            thread2.Start();
        }
