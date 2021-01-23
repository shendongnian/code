    private async void button2_Click(object sender, EventArgs e)
    {
        string file = files[0];
        Task<string> task = Task.Run(() => ProcessFile(file));       
        rtTextArea.Text = await task;
    }
    private string ProcessFile(string file)
    {
        using (TesseractEngine tess = new TesseractEngine("tessdata", "dic", 
                                                          EngineMode.TesseractOnly))
        {
            Page p = tess.Process(Pix.LoadFromFile(file));
            return p.GetText();
        }
    }
