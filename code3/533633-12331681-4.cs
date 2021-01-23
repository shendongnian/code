    string[] files;
    List<string>  paths = new List<string>() ;
    private void button1_Click(object sender, EventArgs e)
    {          
         if (openFileDialog1.ShowDialog() == DialogResult.OK)
         {
             files = openFileDialog1.SafeFileNames;
             paths.AddRange(openFileDialog1.FileNames.ToList());
             for (int i = 0; i < files.Length; i++)
             {
                 listBox1.Items.Add(files[i]);
             }
         }          
    }
