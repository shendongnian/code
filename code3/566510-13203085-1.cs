    private Thread _thread;
    private void Kickoff()
    {
        _thread = new Thread(() => ScheduleWork(listBox1));
        thread.Start();
    }
    private void ScheduleWork(ListBox box)
    {                  
        for(int y = 0; y <100; y++)
        {
            String line = Sp.ReadLine();
            box.Dispatcher.BeginInvoke((Action<string>)(str) => 
                listBox1.Items.Add(str),
                line);
        }
    }
