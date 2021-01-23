    private void button1_Click(object sender, EventArgs e)
    {
        listBox1.SelectedIndex = 0;
        startChild((string)listBox1.SelectedItem);
    }
    void startChild(string data)
    {
        ProcessStartInfo psi = new ProcessStartInfo("child.exe", data);
        Process p = Process.Start(psi);
        p.WaitForExit();
        if (p.HasExited)
        {
            if ((listBox1.SelectedIndex + 1) < listBox1.Items.Count)
            {
                listBox1.SelectedIndex++;
                startChild((string)listBox1.SelectedItem);
            }
        }
    }
