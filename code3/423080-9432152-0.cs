    string text = "";
    using (WebClient wc = new WebClient())
    {
        text = wc.DownloadString(new Uri(Settings.Default.patchCheck));
    }
    textBox1.Text = text;
