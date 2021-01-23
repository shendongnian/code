You don't dispose the StreamReader. Try this:  <br />
    private void Form1_Load(object sender, EventArgs e)
    {
        StreamReader sr = null; // declare the StreamReader outside the try-catch-finally block
        try
        {
    
            sr = new StreamReader(PathFile);
            string line = sr.ReadLine();
            while (line != null)
            {
                comboBox1.Items.Add(line);
                line = sr.ReadLine();
            }
    
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            if (sr != null)
            {
                 sr.Dispose(); // dispose the StreamReader if it's not null
            }
        }
    }
