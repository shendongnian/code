    private void button2_Click(object sender, EventArgs e)
    {
       try
       {
          IEnumerable<string> files = System.IO.Directory.EnumerateFiles(@"C:\", "*.txt*", System.IO.SearchOption.AllDirectories);
          foreach (var f in files)
          {
             listBox1.Items.Add(String.Format("{0}", f)); 
          }
       }
       catch (Exception) { }
    }
