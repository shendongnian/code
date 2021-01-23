    try
    {
        using (Stream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/textme.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                int[] test = new int[] { 0, 12, 23, 46 };
                sw.Write("sadadasdsadsadsadas");
                for (int i = 0; i < test.Length; i++)
                {
                    sw.WriteLine("<chipNr>" + test[i] + "<chipNr>");
                    Console.WriteLine("<chipNr>" + test[i] + "<chipNr>");
                }
                sw.Close();                    
            }
            fs.Close();
        } 
                
    }
    catch (IOException)
    {
        MessageBox.Show("ERROR THROWN");
    }
