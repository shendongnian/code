    private void button2_Click(object sender, EventArgs e) 
    { 
        string ReadFile1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "file.dat"); 
        string WriteFile1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "test.png"); 
        byte[] TMP = File.ReadAllBytes(ReadFile1);
        byte[] pngStartSequence = new byte[] { (byte)'P', (byte)'N', (byte)'G' };
        byte[] pngEndSequence = new byte[] { (byte)'I', (byte)'E', (byte)'N', (byte)'D' };
        int start1 = IndexOf(TMP, pngStartSequence, 0);
        if (start1 == -1)
        {
           // no PNG present
           return;
        }
        int end1 = IndexOf(TMP, pngEndSequence, start1);
        if (end1 == -1)
        {
           // no IEND present
           return;
        }
        int pngLength = (end1 + 9) - start1;
        byte[] PNG = new byte[pngLength];
        Array.Copy(TMP, start1, PNG, 0, pngLength);
        File.WriteAllBytes(WriteFile1, PNG); 
    } 
