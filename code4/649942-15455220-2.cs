        bool semaphore = true;
        int i = 0;
        int j = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            bool semaphore = true;
            ExecuteAsync(()=>
                {
                    while (semaphore)
                    {
                        //Dispatch a call to the UI thread to change the label
                        Invoke((MethodInvoker)(() => ChangeLabel(label1, i.ToString())));
                        i++;
                        Thread.Sleep(50);
                        if (i > 5000)
                        {
                            i = 0;
                        }
                    }
                });
        }
        
        //Executes a function on a ThreadPool thread
        private void ExecuteAsync(Action action)
        {
            ThreadPool.QueueUserWorkItem(
                obj => action());
        }
        private void ChangeLabel(Label label, string labelText)
        {
            label.Text = labelText;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            semaphore = false;
            ExecuteAsync(() =>
                    {
                        while (!semaphore)
                        {
                            //Dispatch a call to the UI thread to change the label
                            Invoke((MethodInvoker)(() => ChangeLabel(label2, j.ToString())));
                            j++;
                            Thread.Sleep(50);
                            if (j > 5000)
                            {
                                i = 0;
                            }
                        }
                    });
        }
