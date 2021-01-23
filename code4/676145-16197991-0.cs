    StreamWriter sw = File.AppendText("log.csv");                
    {
        sw.Write(TextBox21.Text + ",");  // Column 1
        sw.WriteLine(TextBox41.Text);    // Column 2
    }
    sw.Close();
