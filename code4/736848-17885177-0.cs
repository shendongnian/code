    private void Form1_Load(object sender, EventArgs e)
    {
        StreamReader sr = new StreamReader(PathFile);
        try
        {
            string line = sr.ReadLine();
            while (line != null)
            {
                comboBox1.Items.Add(line);
                line = sr.ReadLine();
            }
            sr.Dispose();
            sr = null; 
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally //Just in case any exception is thrown.
        {
           if (sr != null)
               sr.Dispose();
               sr = null;
        }
    }
