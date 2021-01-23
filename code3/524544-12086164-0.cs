    private void timer1_Tick(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"D:\Hello.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now);
            lbTimer.Items.Add(DateTime.Now);
            sw.Close();
            fs.Close();
            
        }
