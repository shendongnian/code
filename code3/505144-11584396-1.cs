    private void button1_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Invoke(new MethodInvoker(() => updateLabel(i)));
                Invoke(new MethodInvoker(() => longerUITask(i)));
            }
        });
    }
    
    private void longerUITask(int i)
    {
        //do databinding that will take a second or two
        Thread.Sleep(1000);
    }
    
    private void updateLabel(int i)
    {
        label1.Text = i.ToString();
    }
