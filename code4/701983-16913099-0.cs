    private void button1_Click(object sender, EventArgs e)
    {
        Application.ExitThread();
        MessageBox.Show("This won't be shown because the UI is being shut down.");
        Debug.WriteLine("But this is still executed");
    }
