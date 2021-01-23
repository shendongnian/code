    private void button1_Click(object sender, System.EventArgs e)
    {
        openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
        openFileDialog1.FilterIndex = 1;
       if(openFileDialog1.ShowDialog() == DialogResult.OK)
       {
          System.IO.StreamReader sr = new 
             System.IO.StreamReader(openFileDialog1.FileName);
          MessageBox.Show(sr.ReadToEnd());
          sr.Close();
       }
