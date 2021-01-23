    private Thread _thread;
    private void Kickoff()
    {
        _thread = new Thread(() => ScheduleWork(listBox1));
        thread.Start();
    }
    private void ScheduleWork(ListBox box)
    {
        box.Dispatcher.BeginInvoke((Action)() => Fill(box));
    }
    private void Fill(ListBox box)
    {                           
        for(int y = 0; y <100; y++)
        {
            String line = Sp.ReadLine();
            listBox1.Items.Add(line);
        }
    }
