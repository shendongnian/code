    string str = string.Empty;
    public void DoStuff()
    {
        System.Threading.ThreadPool.QueueUserWorkItem(WorkerThread);
    }
    
    void WorkerThread(object unused)
    {
        for (int i = 0; i < 1000; i++)
        {
            str += "0";
            if (updatedUI)
            {
                updatedUI = false;
                BeginInvoke(new Action<string>(UpdateUI), str);
            }
        }
        BeginInvoke(new Action<string>(UpdateUI), str);
    }
    
    private volatile bool updatedUI = true;
    void textbox1_Paint(object sender, PaintEventArgs e) // event hooked up in Form constructor
    {
        updatedUI = true;
    }
    void UpdateUI(string str)
    {
        textBox1.Text = str;
    }
