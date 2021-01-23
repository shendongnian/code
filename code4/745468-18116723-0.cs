    public void AddText()
    {            
        using (FileStream fs = new FileStream(@"myFilePath.txt", FileMode.Open, FileAccess.Read))
        {
            int bufferSize = 50; 
            byte[] c = null;             
            while (fs.Length - fs.Position > 0)
            {
                c = new byte[bufferSize];
                fs.Read(c , 0,c.Length);
    
                string newText = new string(UnicodeEncoding.ASCII.GetChars(c));
                this.BeginInvoke((Action)(() => richTextBox1.Text += newText));
    
                Thread.Sleep(100);
             }                
        }        
    }
