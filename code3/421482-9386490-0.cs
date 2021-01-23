    private void button3_Click(object sender, EventArgs e)
    {
       string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
       string mp3FilePath = Path.Combine(path, "LMFAO - Party Rock Anthem.mp3");
       axWindowsMediaPlayer1.URL = mp3FilePath;
    }
