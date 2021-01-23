    private void Form1_Load(object sender, EventArgs e)
    {
       StreamReader sr = new Streamreader(YourTxtFilePath);
       string str = null;
       while( (str = sr.ReadLine()) != null)
       {
         if (cmbItems.SelectedIndex == -1) // If the comboBox is empty
         {
           cmbItems.Items.Add(str);     // Add the strings in the .txt file
         }
       }
    }
