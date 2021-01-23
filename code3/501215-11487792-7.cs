    private static int IndexOf(byte[] array, byte[] sequence, int startIndex)
    {
        if (sequence.Length == 0)
            return -1;
        int found = 0;
        for (int i = startIndex; i < array.Length; i++)
        {
            if (array[i] == sequence[found])
            {
                if (++found == sequence.Length)
                {
                    return i - found + 1;
                }
            }
            else
            {
                found = 0;
            }
        }
        return -1;
    }
    private void button2_Click(object sender, EventArgs e) 
    { 
        string ReadFile1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "file.dat"); 
        string WriteFile1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "test.png"); 
        byte[] TMP = File.ReadAllBytes(ReadFile1);
        byte[] pngStartSequence = new byte[] { 0x89, 0x50, 0x4E, 0x47 };
        byte[] pngEndSequence = new byte[] { 0x49, 0x46, 0x4E, 0x44 };
        int start1 = IndexOf(TMP, pngStartSequence, 0);
        if (start1 == -1)
        {
           // no PNG present
           MessageBox.Show("Could not find PNG header");
           return;
        }
        int end1 = IndexOf(TMP, pngEndSequence, start1 + pngStartSequence.Length);
        if (end1 == -1)
        {
           // no IEND present
           MessageBox.Show("Could not find PNG footer");
           return;
        }
        int pngLength = end1 - start1 + 8;
        byte[] PNG = new byte[pngLength];
        Array.Copy(TMP, start1, PNG, 0, pngLength);
        File.WriteAllBytes(WriteFile1, PNG); 
    } 
