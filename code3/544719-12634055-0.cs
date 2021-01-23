    if (File.Exists(txtBaseAddress.Text))
    {
        StreamReader sr = new StreamReader(txtBaseAddress.Text);
        string line;
        string fileText = "";
        while ((line = sr.ReadLine()) != null)
        {
            if (line.Contains("="))
            {
                fileText += line;
            }
        } 
        sr.Close();
        if (fileText != "")
        {
            try
            {
                StreamWriter sw = new StreamWriter(txtDestAddress.Text);
                sw.Write(fileText);
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
