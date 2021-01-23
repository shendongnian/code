    private void Form1_Load(object sender, EventArgs e)
    {
       StreamReader sr = new Streamreader(YourTxtFilePath);
       string str = null;
       while( (str = sr.ReadLine()) != null)
       {
         if (cmbItems.Items.Count == 0) // If the comboBox is empty
         {
           cmbItems.Items.Add(str);     // Add the strings in the .txt file
         }
       }
    }
