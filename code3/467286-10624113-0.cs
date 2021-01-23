    Thread.Sleep(0500);
    try
    {
        using(System.IO.StreamReader textFile = new System.IO.StreamReader(string.Format("C:\\Mavro\\MavBridge\\{0}\\Comment.txt", selectedPath)))
        {
            richTextBox1.Text = textFile.ReadToEnd();
            textFile.Close();
        }
    
    }
    catch
    {                
        MessageBox.Show("Error: File cannot be opened!", "Error");
    }
