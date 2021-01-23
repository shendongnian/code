    private async void button1(object sender, EventArgs e)
    {
        txtOutput.Text += "Auto-collecting variables. This may take several minutes";
        string v = await Task.Run(() => foo());
        txtOutput.Text += "\n" + v;
        string b = await Task.Run(() => bar());
        txtOutput.Text += "\n" + b;
        txtOutput.SelectionStart = txtOutput.Text.Length;
        txtOutput.ScrollToCaret(); //scrolls to the bottom of textbox
    }
